﻿using FluentValidation;

namespace API.Payment.Feature.Users.UpdateEmail;

public class UpdateEmailUserCommandValidator : AbstractValidator<UpdateEmailUserCommand>
{
    public UpdateEmailUserCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Email)
            .NotEmpty()
            .MaximumLength(254)
            .EmailAddress();

    }
}