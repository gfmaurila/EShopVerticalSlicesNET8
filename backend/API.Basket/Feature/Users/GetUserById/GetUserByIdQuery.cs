using API.Basket.Feature.Users.GetUser;
using MediatR;
using poc.core.api.net8.Response;

namespace API.Basket.Feature.Users.GetUserById;


public class GetUserByIdQuery : IRequest<ApiResult<UserQueryModel>>
{
    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; private set; }
}