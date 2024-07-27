﻿using FluentValidation;

namespace API.Ordering.Feature.Auth.AuthNewPassword;

public class AuthNewPasswordCommandValidator : AbstractValidator<AuthNewPasswordCommand>
{
    public AuthNewPasswordCommandValidator()
    {
        RuleFor(command => command.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(100)
            .Matches(@"(?=.*\d)") // Pelo menos um número
            .Matches(@"(?=.*[a-z])") // Pelo menos uma letra minúscula
            .Matches(@"(?=.*[A-Z])") // Pelo menos uma letra maiúscula
            .Matches(@"(?=.*\W)") // Pelo menos um caractere especial
            .Matches(@"^(?!.*123).*$") // Não permitir a sequência "123"
            .WithMessage("A senha deve conter pelo menos uma letra maiúscula, uma letra minúscula, um número, um caractere especial e não pode conter sequências simples como '123'.");

        RuleFor(command => command.ConfirmPassword)
            .Equal(command => command.Password)
            .WithMessage("A confirmação da senha deve ser igual à senha.");

        RuleFor(command => command.Token)
            .NotEmpty()
            .WithMessage("O token é obrigatório.");
    }
}