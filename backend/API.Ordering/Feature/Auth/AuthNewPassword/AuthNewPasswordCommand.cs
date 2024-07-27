﻿using MediatR;
using poc.core.api.net8.Response;
using System.ComponentModel.DataAnnotations;

namespace API.Ordering.Feature.Auth.AuthNewPassword;

public class AuthNewPasswordCommand : IRequest<ApiResult<AuthNewPasswordResponse>>
{
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }

    [Required]
    public string Token { get; set; }
}
