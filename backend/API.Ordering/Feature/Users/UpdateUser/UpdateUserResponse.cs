using poc.core.api.net8;

namespace API.Ordering.Feature.Users.UpdateUser;

public class UpdateUserResponse : BaseResponse
{
    public UpdateUserResponse(Guid id) => Id = id;
    public Guid Id { get; }
}
