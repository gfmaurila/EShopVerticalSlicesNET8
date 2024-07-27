using MediatR;
using poc.core.api.net8.Response;

namespace API.Payment.Feature.Users.GetUser;

public class GetUserQuery : IRequest<ApiResult<List<UserQueryModel>>>
{
    public GetUserQuery()
    {
    }
}
