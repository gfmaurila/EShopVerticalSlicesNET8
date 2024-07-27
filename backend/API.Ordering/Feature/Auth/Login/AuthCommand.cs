﻿using MediatR;
using poc.core.api.net8.Response;
using System.ComponentModel.DataAnnotations;

namespace API.Ordering.Feature.Auth.Login;

public class AuthCommand : IRequest<ApiResult<AuthTokenResponse>>
{
    [Required]
    [MaxLength(200)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}