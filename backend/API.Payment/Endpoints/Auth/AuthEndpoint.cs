﻿using API.Payment.Feature.Auth.Login;
using Carter;
using MediatR;
using Microsoft.OpenApi.Models;
using poc.core.api.net8.API.Models;

namespace poc.vertical.slices.net8.Endpoints.Auth;

public class AuthEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/login", HandleAuth)
            .WithName("Auth")
            .Produces<AuthTokenResponse>(StatusCodes.Status200OK)
            .Produces<ApiResponse>(StatusCodes.Status400BadRequest)
            .Produces<ApiResponse>(StatusCodes.Status500InternalServerError)
            .WithOpenApi(x =>
            {
                x.OperationId = "Auth";
                x.Summary = "Login";
                x.Description = "Login";
                x.Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Auth" } };
                return x;
            })
            ;
    }
    private async Task<IResult> HandleAuth(AuthCommand command, ISender sender)
    {
        var result = await sender.Send(command);
        if (!result.Success)
            return Results.BadRequest(result);
        return Results.Ok(result);
    }
}