using poc.core.api.net8;

namespace API.Register.Feature.Users.DeleteUser;

public class DeleteUserResponse : BaseResponse
{
    public DeleteUserResponse(Guid id) => Id = id;
    public Guid Id { get; }
}
