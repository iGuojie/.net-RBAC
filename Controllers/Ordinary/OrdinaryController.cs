using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_Api.Tool.JsonResultTool;
using JsonResult = Web_Api.Tool.JsonResultTool.JsonResult;

namespace Web_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdinaryController : ControllerBase
{

    private readonly ILogger<OrdinaryController> _logger;

    public OrdinaryController(ILogger<OrdinaryController> logger)
    {
        _logger = logger;
    }

    [HttpGet("Ordinary")]
    public JsonResult Get()
    {
        return ResultTool.Success("普通用户访问");
    }
}