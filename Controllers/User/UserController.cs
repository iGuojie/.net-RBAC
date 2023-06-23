using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api.Data;
using Web_Api.Tool.JsonResultTool;
using Web_Api.Tool.Jwt;
using JsonResult = Web_Api.Tool.JsonResultTool.JsonResult;

namespace Web_Api.Controllers.User;

[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase
{
    private readonly JwtTool jwtTool;
    private readonly MyDbContext _dbContext;

    public UserController(JwtTool jwtTool, MyDbContext myDbContext)
    {
        this.jwtTool = jwtTool;
        _dbContext = myDbContext;
    }
    
    [HttpPost("Login")]
    public JsonResult Login([FromBody] Dictionary<string, string> values)
    {
        var user = _dbContext.Users
            .Include(u => u.Roles)
            .FirstOrDefault(u => u.NickName == values["username"] && u.Password == values["password"]);
        if(user == null){
            return ResultTool.Success("账号或密码错误");
        }
        
        List<string> roles = user.Roles.Select(u => u.Name).ToList();
        return ResultTool.Success(jwtTool.GenerateJwt(roles));
    }
}