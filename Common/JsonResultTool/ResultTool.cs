using System;
using System.Collections.Generic;

namespace Web_Api.Tool.JsonResultTool;

public static class ResultTool
{
    public static Dictionary<ResultCode, string> DescriptionsDictionary = EnumHelper.GetDescriptions<ResultCode>();
    
    
    public static JsonResult Success()
    {
        return new JsonResult(true);
    }

    public static JsonResult Success(Object data)
    {
        return new JsonResult(true, data);
    }

    public static JsonResult Fail()
    {
        return new JsonResult(false);
    }

    public static JsonResult Fail(ResultCode resultCode)
    {
        return new JsonResult(false, resultCode);
    }

    public static JsonResult Fail(ResultCode resultCode, string msg)
    {
        return new JsonResult(false, resultCode, msg);
    }

    public static JsonResult Fail(string msg)
    {
        return new JsonResult(false, msg);
    }

    public static JsonResult Fail(bool b, ResultCode resultCode, string message)
    {
        return new JsonResult(false, resultCode, message);
    }
}
