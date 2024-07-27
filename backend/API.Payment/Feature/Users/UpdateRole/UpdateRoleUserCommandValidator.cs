using FluentValidation;

namespace API.Payment.Feature.Users.UpdateRole;

public class UpdateRoleUserCommandValidator : AbstractValidator<UpdateRoleUserCommand>
{
    public UpdateRoleUserCommandValidator()
    {
    }
}
