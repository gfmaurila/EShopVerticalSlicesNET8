using API.Employee.Feature.Auth.Login;
using API.Employee.Tests.Integration.Features.Auth.Fakes;
using API.Employee.Tests.Integration.Features.Users.Data;
using API.Employee.Tests.Integration.Utilities;
using poc.core.api.net8.Response;
using System.Net.Http.Json;

namespace API.Employee.Tests.Integration.Features.Auth.AuthEndpoint;

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
