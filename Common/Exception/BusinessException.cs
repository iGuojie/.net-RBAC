using Web_Api.Tool.JsonResultTool;

namespace Web_Api.Common.Exception;
using System;
public class BusinessException : Exception
{
    public ResultCode ErrorCode { get; set; }

    public BusinessException(string message) : base(message)
    {
        ErrorCode = ResultCode.Fail;
    }

    public BusinessException(ResultCode errorCode, string message = "") : base(message)
    {
        this.ErrorCode = errorCode;
    }
}