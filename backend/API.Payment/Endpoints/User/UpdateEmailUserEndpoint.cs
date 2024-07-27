﻿using API.Payment.Feature.Users.UpdateEmail;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using poc.core.api.net8.API.Models;
using poc.core.api.net8.User;

namespace poc.vertical.slices.net8.Endpoints.User;

public class UpdateEmailUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("api/v1/user/updateemail", HandleUpdateEmail)
            .WithName("UpdateUserEmail")
            .Produces<ApiResponse>(StatusCodes.Status200OK)
            .Produces<ApiResponse>(StatusCodes.Status400BadRequest)
            .Produces<ApiResponse>(StatusCodes.Status404NotFound)
            .Produces<ApiResponse>(StatusCodes.Status500InternalServerError)
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Summary = "Atualizar email de usuário",
                Description = "Atualiza o email de um usuário existente, identificado pelo ID no corpo da requisição.",
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

    private async Task<IResult> HandleUpdateEmail(UpdateEmailUserCommand command, ISender sender)
    {
        var result = await sender.Send(command);

        if (!result.Success)
            return Results.BadRequest(result);

        return Results.Ok(result);
    }
}
