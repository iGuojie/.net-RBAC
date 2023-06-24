using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_Api.Common.JsonResultTool;
using JsonResult = Web_Api.Common.JsonResultTool.JsonResult;

namespace Web_Api.Controllers.Anonymous;

[ApiController]
[Route("[controller]")]
public class AnonymousController : ControllerBase
{

    private readonly ILogger<AnonymousController> _logger;

    public AnonymousController(ILogger<AnonymousController> logger)
    {
        _logger = logger;
    }

    [HttpGet("Anonymous")]
    public JsonResult Get()
    {
        return ResultTool.Success("匿名用户访问");
    }
}