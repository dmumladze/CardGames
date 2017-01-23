using System;
using System.Text;
using System.Buffers;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using CardGames.Web.Services;

namespace CardGames.Web.Middleware
{
    public class BuraMiddleware
    {
        public const int BufferSize = 1024;

        private WebSocket socket;
        private RequestDelegate pipeline;
        private IGameRepository repository;
        private PathString path;
        private ArrayPool<byte> pool;

        public BuraMiddleware(RequestDelegate next, IGameRepository repository, string path)
        {
            this.pipeline = next;
            this.repository = repository;
            this.path = new PathString(path);
            this.pool = ArrayPool<byte>.Create(5, 5);            
        }

        public async Task HandleRequest()
        {            
            while (this.socket.State == WebSocketState.Open)
            {
                var buffer = this.pool.Rent(BufferSize);
                var seg = new ArraySegment<byte>(buffer);

                var sending = Encoding.UTF8.GetBytes(DateTime.Now.ToString());  

                var sb = new StringBuilder();    

                var incoming = await this.socket.ReceiveAsync(seg, CancellationToken.None);
                sb.Append(Encoding.UTF8.GetString(seg.Array));

                while (!incoming.EndOfMessage)                
                {                   
                    incoming = await this.socket.ReceiveAsync(seg, CancellationToken.None);
                    sb.Append(Encoding.UTF8.GetString(seg.Array, 0, incoming.Count));
                }

                this.pool.Return(buffer);
                
                Debug.WriteLine($"Inside loop: {Thread.CurrentThread.ManagedThreadId}\r\nMessage: {sb.ToString()}");
                
                var outgoing = new ArraySegment<byte>(sending, 0, sending.Length);  
                await this.socket.SendAsync(outgoing, WebSocketMessageType.Text, true, CancellationToken.None);

                Debug.WriteLine("Message Sent");
            }

            Debug.WriteLine("Outside loop: {0}", Thread.CurrentThread.ManagedThreadId);
        } 

        public async Task Invoke(HttpContext context)
        {
            if (!context.WebSockets.IsWebSocketRequest || !context.Request.Path.StartsWithSegments(this.path))
            {
                await this.pipeline.Invoke(context);
                return;
            }

            Debug.WriteLine("Accepted");

            this.socket = await context.WebSockets.AcceptWebSocketAsync();
            await this.HandleRequest();
            
            Debug.WriteLine("Accepted 2");
        }                   
    } 

    public static class MiddlewareRegistrationExtensions 
    {
        public static void UseBuraMiddleware(this IApplicationBuilder builder)
        {          
            builder.UseMiddleware<BuraMiddleware>("/ws/bura");
        }  
    }  
}