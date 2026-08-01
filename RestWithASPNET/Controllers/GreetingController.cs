using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Model;

namespace RestWithASPNET.Controllers;

[ApiController]
[Route("[controller]")]
public class GreetingController : ControllerBase
{

    private static long _counter = 0;
    private static readonly string _teamplate = "Hello , {0}!";
    [HttpGet(Name = "GetGrenting")]
    public Greeting Get([FromQuery] string name = "World")
    {
        var id = Interlocked.Increment(ref _counter);
        var content = string.Format(_teamplate,name);
        return new Greeting (id,content);
    }
}
