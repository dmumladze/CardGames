using System;
using Microsoft.AspNetCore.Mvc;

namespace CardGames.Web
{
    [Route("api/[controller]")]
    public abstract class ApiController : Controller 
    {
    }
}
