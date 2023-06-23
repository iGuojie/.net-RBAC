using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Web_Api.Common.Exception;
using Web_Api.Data;
using Web_Api.Tool.JsonResultTool;

public class MyAuthenrizationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IAuthorizationService _authorizationService;
    private readonly IAuthenticationSchemeProvider _schemes;
    private readonly CacheHelper _cache;

    public MyAuthenrizationMiddleware(RequestDelegate next, IAuthorizationService authorizationService, 
        IAuthenticationSchemeProvider schemes, CacheHelper cacheHelper)
    {
        _next = next;
        _authorizationService = authorizationService;
        _schemes = schemes;
        _cache = cacheHelper;
    }

    public async Task InvokeAsync(HttpContext context, MyDbContext dbContext)
    {
        var url = context.Request.Path.Value;
        var resources = dbContext.Resources.Include(r => r.Roles).ToList();
        var resource = resources.FirstOrDefault(r => r.Url == url);
        if (resource == null)
        {
            throw new BusinessException(ResultCode.TokenAuthorizeFailed,
                ResultTool.DescriptionsDictionary[ResultCode.TokenAuthorizeFailed]);
        }
        if (resource.Roles?.Count == 0)
        {
            await _next(context);
            return;
        }
        
        var defaultAuthenticate = await _schemes.GetDefaultAuthenticateSchemeAsync();
        var authticationResult = await context.AuthenticateAsync(defaultAuthenticate.Name);

        // 如果认证结果失败，直接异常
        if (!(authticationResult?.Succeeded ?? false))
        {
            if (authticationResult.Failure is SecurityTokenExpiredException)
                throw new SecurityTokenExpiredException();
            throw new SecurityTokenException();
        }
        else
        {
            var user = context.User;
            var authenticateResult = await context.AuthenticateAsync(defaultAuthenticate.Name);
            // 查看是否有对应的角色
            if (authenticateResult?.Principal != null)
            {
                // 获取所有的角色
                var roles = authenticateResult.Principal.FindAll(ClaimTypes.Role);
                foreach (var claim in roles)
                {
                    var items = claim.Value.Split(',');
                    foreach (var item in items)
                    {
                        if (resource.Roles.Any(r => r.Name == item))
                        {
                            await _next(context);
                            return;
                        }
                    }
                        
                }
                throw new BusinessException(ResultCode.TokenAuthorizeFailed, 
                    ResultTool.DescriptionsDictionary[ResultCode.TokenAuthorizeFailed]);
                    
            }
        }
        await _next(context);
    }
}