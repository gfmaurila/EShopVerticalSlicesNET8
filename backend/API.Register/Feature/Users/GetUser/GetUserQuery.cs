using MediatR;
using poc.core.api.net8.Response;

namespace API.Register.Feature.Users.GetUser;

public class GetUserQuery : IRequest<ApiResult<List<UserQueryModel>>>
{
    public GetUserQuery()
    {
    }
}
