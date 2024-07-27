using FluentValidation;

namespace API.Webhooks.Feature.Users.UpdateRole;

public class UpdateRoleUserCommandValidator : AbstractValidator<UpdateRoleUserCommand>
{
    public UpdateRoleUserCommandValidator()
    {
    }
}
