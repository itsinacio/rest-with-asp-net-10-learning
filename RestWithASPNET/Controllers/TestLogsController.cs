using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestLogsController : ControllerBase
{
    private readonly ILogger<TestLogsController> _logger;
    public TestLogsController(ILogger<TestLogsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult LogTest()
    {
        _logger.LogTrace("This is a Trace log message.");
        _logger.LogDebug("This is a Debug log message.");
        _logger.LogInformation("This is a Information log message.");
        _logger.LogWarning("This is a Warning log message.");
        _logger.LogError("This is a Error log message.");
        _logger.LogCritical("This is a Critical log message.");
        return Ok("All types messages logs");
    }
}
