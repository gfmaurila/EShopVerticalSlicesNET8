﻿using API.Employee.Tests.Integration.Features.Auth.AuthEndpoint;
using API.Employee.Tests.Integration.Features.Users.Data;
using API.Employee.Tests.Integration.Features.Users.Fakes;
using API.Employee.Tests.Integration.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using poc.core.api.net8.API.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace API.Employee.Tests.Integration.Features.Users.UpdatePasswordUserEndpoint;

public class UpdatePasswordUserInvalidTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly AuthToken _auth;
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory<Program> _factory;

    public UpdatePasswordUserInvalidTests(CustomWebApplicationFactory<Program> factory)
    {
        _auth = new AuthToken();
        _factory = factory;
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }

    [Fact]
    public async Task ShouldUser()
    {
        // Arrange - Auth
        var token = await _auth.GetAuthAsync(_factory, _client);
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Data.Token);

        // Limpa base
        await UserRepo.ClearDatabaseAsync(_factory);

        // Arrange

        //Arrange command
        var id = await UserRepo.GetUserById(_factory);

        var command = UserFake.UpdatePasswordUserInvalidCommand(id);

        var url = "/api/v1/user/updatepassword";

        // Envia o comando para criar um usuário
        var httpResponse = await _client.PutAsJsonAsync(url, command);
        _client.DefaultRequestHeaders.Clear();

        // Extrai o JSON da resposta
        var jsonResponse = await httpResponse.Content.ReadFromJsonAsync<ApiResponse>();

        // Verifica se o campo "success" é false
        Assert.False(jsonResponse.Success);

        // Verifica se a lista de erros contém as mensagens específicas
        var expectedErrors = new List<string>
        {
            "A confirmação da senha deve ser igual à senha."
        };

        Assert.All(expectedErrors, error => Assert.Contains(jsonResponse.Errors.Select(e => e.Message), e => e == error));

        // Verifica se a quantidade de erros é a esperada
        Assert.Equal(expectedErrors.Count, jsonResponse.Errors.Count());

        // Limpa base
        await UserRepo.ClearDatabaseAsync(_factory);
    }
}
