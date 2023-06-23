using System.ComponentModel;

namespace Web_Api.Tool.JsonResultTool;

public enum ResultCode
{
    // 信息响应 (10000+)
    // 成功响应 (20000+)
    // 重定向   (30000+)
    // 客户端错误(40000+)
    // 服务器错误(50000+)
    // 权限相应  (60000+)
    [Description("操作失败！")]
    Fail = 10000,
    [Description("请求成功！")]
    Success = 20000,
    [Description("token认证失败！")]
    TokenAuthenticationFailed = 60000,
    [Description("token失效！")]
    TokenExpired = 60001,
    [Description("鉴权失败！")]
    TokenAuthorizeFailed = 60002,
}