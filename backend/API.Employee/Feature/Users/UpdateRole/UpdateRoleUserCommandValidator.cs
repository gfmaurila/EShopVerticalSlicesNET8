using FluentValidation;

namespace API.Employee.Feature.Users.UpdateRole;

public class UpdateRoleUserCommandValidator : AbstractValidator<UpdateRoleUserCommand>
{
    public UpdateRoleUserCommandValidator()
    {
    }
}
