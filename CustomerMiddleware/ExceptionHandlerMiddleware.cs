using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Web_Api.Common.Exception;
using Web_Api.Tool.JsonResultTool;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.OK;

        JsonResult result;

        if (exception is BusinessException businessException)
        {
            // BusinessException处理
            result = ResultTool.Fail(businessException.ErrorCode, businessException.Message);
        } else if (exception is SecurityTokenExpiredException securityTokenExpiredException){
            result = ResultTool.Fail(ResultCode.TokenExpired);
        } else if(exception is SecurityTokenException){
            result = ResultTool.Fail(ResultCode.TokenAuthenticationFailed);
        } else
        {
            // 其他未处理异常处理
            // result = ResultTool.Fail(ResultCode.Fail, exception.Message);
            result = ResultTool.Fail(ResultCode.Fail, "系统异常！");
        }
/*
 * 
 */
        return context.Response.WriteAsJsonAsync(result);
    }

}
