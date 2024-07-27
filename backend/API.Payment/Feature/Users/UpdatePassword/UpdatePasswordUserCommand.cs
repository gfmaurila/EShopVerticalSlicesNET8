﻿using MediatR;
using poc.core.api.net8.Response;
using System.ComponentModel.DataAnnotations;

namespace API.Payment.Feature.Users.UpdatePassword;

public class UpdatePasswordUserCommand : IRequest<ApiResult<UpdatePasswordUserResponse>>
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}
