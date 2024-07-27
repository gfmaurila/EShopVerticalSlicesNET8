using FluentValidation;

namespace API.Identity.Feature.Users.GetUserById;


public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(command => command.Id).NotEmpty();
    }
}