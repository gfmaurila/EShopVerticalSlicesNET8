using API.Basket.Feature.Auth.Login;
using API.Basket.Tests.Integration.Features.Auth.Fakes;
using API.Basket.Tests.Integration.Features.Users.Data;
using API.Basket.Tests.Integration.Utilities;
using poc.core.api.net8.Response;
using System.Net.Http.Json;

namespace API.Basket.Tests.Integration.Features.Auth.AuthEndpoint;

public class AuthToken
{
    public async Task<ApiResult<AuthTokenResponse>> GetAuthAsync(CustomWebApplicationFactory<Program> factory, HttpClient client)
    {
        var command = AuthFake.GetAuthAsync();
        await UserRepo.GetAuth(factory);
        var httpResponse = await client.PostAsJsonAsync("/api/v1/login", command);
        return await httpResponse.Content.ReadFromJsonAsync<ApiResult<AuthTokenResponse>>();
    }
}
