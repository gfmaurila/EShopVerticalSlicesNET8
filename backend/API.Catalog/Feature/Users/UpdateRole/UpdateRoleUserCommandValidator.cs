using FluentValidation;

namespace API.Catalog.Feature.Users.UpdateRole;

public class UpdateRoleUserCommandValidator : AbstractValidator<UpdateRoleUserCommand>
{
    public UpdateRoleUserCommandValidator()
    {
    }
}
