﻿using FluentValidation;

namespace API.Employee.Feature.Users.GetUserById;


public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(command => command.Id).NotEmpty();
    }
}