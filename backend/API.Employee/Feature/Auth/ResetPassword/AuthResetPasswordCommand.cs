﻿using MediatR;
using poc.core.api.net8.Response;
using System.ComponentModel.DataAnnotations;

namespace API.Employee.Feature.Auth.ResetPassword;

public class AuthResetPasswordCommand : IRequest<ApiResult<AuthResetPasswordResponse>>
{
    [Required]
    [MaxLength(200)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
}