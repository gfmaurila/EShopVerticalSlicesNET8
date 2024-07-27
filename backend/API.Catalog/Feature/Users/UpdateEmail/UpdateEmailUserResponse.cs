using poc.core.api.net8;

namespace API.Catalog.Feature.Users.UpdateEmail;

public class UpdateEmailUserResponse : BaseResponse
{
    public UpdateEmailUserResponse(Guid id) => Id = id;
    public Guid Id { get; }
}
