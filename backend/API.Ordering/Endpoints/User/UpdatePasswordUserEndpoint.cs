﻿using API.Ordering.Feature.Users.UpdatePassword;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using poc.core.api.net8.API.Models;
using poc.core.api.net8.User;

namespace poc.vertical.slices.net8.Endpoints.User;

public class UpdatePasswordUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("api/v1/user/updatepassword", HandleUpdatePassword)
            .WithName("UpdateUserPassword")
            .Produces<ApiResponse>(StatusCodes.Status200OK)
            .Produces<ApiResponse>(StatusCodes.Status400BadRequest)
            .Produces<ApiResponse>(StatusCodes.Status404NotFound)
            .Produces<ApiResponse>(StatusCodes.Status500InternalServerError)
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Summary = "Atualizar senha de usuário",
                Description = "Atualiza a senha de um usuário existente. A requisição deve conter o ID do usuário e a nova senha.",
                Tags = new List<OpenApiTag>
                {
                    new OpenApiTag
                    {
                        Name = "Usuários"
                    }
                }
            })
            .RequireAuthorization(new AuthorizeAttribute { Roles = $"{RoleUserAuthConstants.User}, {RoleUserAuthConstants.PutUser}" })
            ;
    }

    private async Task<IResult> HandleUpdatePassword(UpdatePasswordUserCommand command, ISender sender)
    {
        var result = await sender.Send(command);

        if (!result.Success)
            return Results.BadRequest(result);

        return Results.Ok(result);
    }
}

