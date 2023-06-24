using System;

namespace Web_Api.Common.JsonResultTool;

public class JsonResult
{
    public bool Success { get; set; }
    public int Code { get; set; }
    public string? Msg { get; set; }
    public Object? Data { get; set; }

    public JsonResult(){}
    public JsonResult(bool success)
    {
        Success = success;
        Code = success ? (int)ResultCode.Success : (int)ResultCode.Fail;
        Msg = ResultTool.DescriptionsDictionary[(ResultCode)Code];
    }

    
    public JsonResult(bool success, string msg)
    {
        Success = success;
        Code = success ? (int)ResultCode.Success : (int)ResultCode.Fail;
        Msg = msg;
    }

    public JsonResult(bool success, ResultCode resultEnum)
    {
        Success = success;
        Code = success ? (int)ResultCode.Success : (int)resultEnum;
        Msg = ResultTool.DescriptionsDictionary[(ResultCode)Code];
    }

    public JsonResult(bool success, Object data)
    {
        Success = success;
        Code = success ? (int)ResultCode.Success : (int)ResultCode.Fail;
        Msg = ResultTool.DescriptionsDictionary[(ResultCode)Code];
        Data = data;
    }

    public JsonResult(bool success, ResultCode resultEnum, Object data)
    {
        Success = success;
        Code = success ? (int)ResultCode.Success : (int)resultEnum;
        Msg = ResultTool.DescriptionsDictionary[(ResultCode)Code];
        Data = data;
    }

    public JsonResult(bool success, ResultCode resultEnum, string msg)
    {
        Success = success;
        Code = success ? (int)ResultCode.Success : (int)resultEnum;
        this.Msg = msg;
    }
    
}