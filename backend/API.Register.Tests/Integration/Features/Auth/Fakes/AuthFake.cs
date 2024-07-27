﻿using API.Register.Feature.Auth.AuthNewPassword;
using API.Register.Feature.Auth.Login;
using API.Register.Feature.Auth.ResetPassword;
using Bogus;

namespace API.Register.Tests.Integration.Features.Auth.Fakes;

public static class AuthFake
{
    public static AuthNewPasswordCommand AuthNewPasswordCommand()
    {
        var faker = new Faker("pt_BR");

        var command = new AuthNewPasswordCommand()
        {
            Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYTEwQGdtYWlsLmNvbSIsImlkIjoiYzdhMTE1MGYtYmNmMC00M2EzLTkxNzctODcwNmViNGVkMDQzIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQVVUSF9SRVNFVCIsImV4cCI6MTcxMTY5MTYzMSwiaXNzIjoiSnd0QXBpQXV0aCIsImF1ZCI6Ikp3dEFwaUF1dGgifQ.j98quhsXmzjAJfCDYM-ollc7Oe4l95UTbAYuU13qbbA",
            Password = "@Teste1L5a9",
            ConfirmPassword = "@Teste1L5a9"
        };
        return command;
    }


    public static AuthResetPasswordCommand AuthResetPasswordInvalidCommand()
    {
        var faker = new Faker("pt_BR");

        var command = new AuthResetPasswordCommand()
        {
            Email = "testedeleteteste.com.br"
        };
        return command;
    }

    public static AuthResetPasswordCommand AuthResetPasswordCommand()
    {
        var faker = new Faker("pt_BR");

        var command = new AuthResetPasswordCommand()
        {
            Email = "testedelete@teste.com.br"
        };
        return command;
    }

    public static AuthCommand GetAuthAsync()
    {
        var faker = new Faker("pt_BR");

        var command = new AuthCommand()
        {
            Email = "auth@auth.com.br",
            Password = "Test123$"
        };
        return command;
    }

    public static AuthCommand AuthCommand()
    {
        var faker = new Faker("pt_BR");

        var command = new AuthCommand()
        {
            Email = "testedelete@teste.com.br",
            Password = "Test123$"
        };
        return command;
    }

    public static AuthCommand AuthInvalidCommand()
    {
        var faker = new Faker("pt_BR");

        var command = new AuthCommand()
        {
            Email = "testedeleteteste.com.br",
            Password = "Test123$"
        };
        return command;
    }
}
