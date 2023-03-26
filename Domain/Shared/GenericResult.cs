﻿
using SearchText.Domain.Shared.Contracts;

namespace SearchText.Domain.Shared;

public class GenericResult: IResult
{
    public GenericResult(bool success, string message, object data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}