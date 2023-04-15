﻿namespace ShopAPI.Features.RequestHandling.Base;

/// <summary>
///     Error response for api's
/// </summary>
public class ApiErrorResponse
{
    /// <summary>
    ///     Error messages where:
    ///     Key : Property name
    ///     Value : Error message
    /// </summary>
    public Dictionary<string, string> Messages { set; get; } = new();

    /// <summary>
    ///     Main error reason
    /// </summary>
    public string MainErrorMessage { set; get; }
}