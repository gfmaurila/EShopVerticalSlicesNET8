﻿using API.Webhooks.Feature.Users.UpdateUser;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using poc.core.api.net8.API.Models;
using poc.core.api.net8.User;

namespace poc.vertical.slices.net8.Endpoints.User;

public class UpdateUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("api/v1/user", HandleUpdateUser)
            .WithName("UpdateUser")
            .Produces<ApiResponse>(StatusCodes.Status200OK)
            .Produces<ApiResponse>(StatusCodes.Status400BadRequest)
            .Produces<ApiResponse>(StatusCodes.Status404NotFound)
            .Produces<ApiResponse>(StatusCodes.Status500InternalServerError)
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Summary = "Atualizar dados do usuário",
                Description = "Atualiza os dados de um usuário existente, utilizando o ID fornecido no corpo da requisição para identificação. Os dados atualizáveis incluem nome, email, senha, entre outros campos pertinentes.",
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

    private async Task<IResult> HandleUpdateUser(UpdateUserCommand command, ISender sender)
    {
        var result = await sender.Send(command);

        if (!result.Success)
            return Results.BadRequest(result);

        return Results.Ok(result);
    }
}