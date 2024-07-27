using FluentValidation;

namespace API.Identity.Feature.Users.UpdateRole;

public class UpdateRoleUserCommandValidator : AbstractValidator<UpdateRoleUserCommand>
{
    public UpdateRoleUserCommandValidator()
    {
    }
}
