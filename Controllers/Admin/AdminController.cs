using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_Api.Common.JsonResultTool;
using JsonResult = Web_Api.Common.JsonResultTool.JsonResult;

namespace Web_Api.Controllers.Admin;


[ApiController]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger)
    {
        _logger = logger;
    }

    
    [HttpGet("Admin")]
    public JsonResult Get()
    {
        return ResultTool.Success("管理员登录");
    }
}