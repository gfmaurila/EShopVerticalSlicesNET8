﻿using API.Register.Tests.Integration.Features.Auth.AuthEndpoint;
using API.Register.Tests.Integration.Features.Users.Data;
using API.Register.Tests.Integration.Features.Users.Fakes;
using API.Register.Tests.Integration.Utilities;
using Microsoft.AspNetCore.Mvc.Testing;
using poc.core.api.net8.API.Models;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace API.Register.Tests.Integration.Features.Users.CreateUserEndpoint;

public class CreateUserExistingTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly AuthToken _auth;
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory<Program> _factory;

    public CreateUserExistingTests(CustomWebApplicationFactory<Program> factory)
    {
        _auth = new AuthToken();
        _factory = factory;
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }

    [Fact]
    public async Task ShouldUserUserExisting()
    {
        // Limpa base
        await UserRepo.ClearDatabaseAsync(_factory);

        // Arrange - Auth
        var token = await _auth.GetAuthAsync(_factory, _client);
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Data.Token);
        await UserRepo.ClearDatabaseAsync(_factory);

        // Arrange
        var command = UserFake.CreateUserExistingDataCommand();
        await UserRepo.PopulateTestExistingData(_factory);

        var httpResponse = await _client.PostAsJsonAsync("/api/v1/user", command);
        _client.DefaultRequestHeaders.Clear();

        // Verifica se a resposta HTTP é 400 - Bad Request
        Assert.Equal(HttpStatusCode.BadRequest, httpResponse.StatusCode);

        // Extrai o JSON da resposta
        var jsonResponse = await httpResponse.Content.ReadFromJsonAsync<ApiResponse>();

        // Verifica se o campo "success" é false
        Assert.False(jsonResponse.Success);

        // Verifica se a lista de erros contém as mensagens específicas
        var expectedErrors = new List<string>
        {
            "O endereço de e-mail informado já está sendo utilizado."
        };

        Assert.All(expectedErrors, error => Assert.Contains(jsonResponse.Errors.Select(e => e.Message), e => e == error));

        // Verifica se a quantidade de erros é a esperada
        Assert.Equal(expectedErrors.Count, jsonResponse.Errors.Count());

        // Limpa base
        await UserRepo.ClearDatabaseAsync(_factory);
        //_app.Dispose();
    }
}
