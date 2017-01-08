using System;
using System.Text;
using System.Buffers;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CardGames.Web.Middleware
{
    public class WebSocketMiddleware
    {
        public const int BufferSize = 2;

        private WebSocket socket;
        private ArrayPool<byte> pool;

        public WebSocketMiddleware(WebSocket socket)
        {
            this.socket = socket;
            this.pool = ArrayPool<byte>.Create(5, 5);
        }

        public async Task EchoLoop()
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

        static async Task Acceptor(HttpContext context, Func<Task> next)
        {
            if (!context.WebSockets.IsWebSocketRequest)
                return;
            
            Debug.WriteLine("Accepted");
            var socket = await context.WebSockets.AcceptWebSocketAsync();
            var h = new WebSocketMiddleware(socket);
            await h.EchoLoop();
            Debug.WriteLine("Accepted 2");
        }   

        public static void Map(IApplicationBuilder app)
        {
            app.UseWebSockets();
            app.Use(WebSocketMiddleware.Acceptor);
        }                     
    }   
}