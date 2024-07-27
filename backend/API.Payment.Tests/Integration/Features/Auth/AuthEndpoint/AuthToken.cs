using API.Payment.Feature.Auth.Login;
using API.Payment.Tests.Integration.Features.Auth.Fakes;
using API.Payment.Tests.Integration.Features.Users.Data;
using API.Payment.Tests.Integration.Utilities;
using poc.core.api.net8.Response;
using System.Net.Http.Json;

namespace API.Payment.Tests.Integration.Features.Auth.AuthEndpoint;

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
