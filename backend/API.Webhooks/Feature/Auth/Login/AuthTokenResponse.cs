﻿using poc.core.api.net8;

namespace API.Webhooks.Feature.Auth.Login;

public class AuthTokenResponse : BaseResponse
{
    public AuthTokenResponse(string token)
    {
        Token = token;
    }
    public string Token { get; }
}
