using API.Admin.Feature.Users.CreateUser;
using API.Admin.Feature.Users.UpdateEmail;
using API.Admin.Feature.Users.UpdatePassword;
using API.Admin.Feature.Users.UpdateUser;
using API.Admin.Infrastructure.Domain.User;
using Bogus;
using Enumerable.User;
using poc.core.api.net8.Enumerado;
using poc.core.api.net8.Extensions;
using poc.core.api.net8.ValueObjects;

namespace API.Admin.Tests.Integration.Users.Fakes;

internal static class UserFake
{
    #region UserEntity
    public static UserEntity Insert()
    {
        var faker = new Faker("pt_BR");

        var email = new Email(faker.Person.Email);
        var phone = new PhoneNumber(faker.Person.Phone);

        var newUser = new UserEntity(
            faker.Person.FirstName,
            faker.Person.LastName,
            EGender.Male,
            ENotificationType.WhatsApp,
            email,
            phone,
            Password.ComputeSha256Hash("@G21r03a1985"),
            RoleUserAuth(),
            new DateTime(1990, 1, 1));

        return newUser;
    }

    public static UserEntity Insert(Email email)
    {
        var faker = new Faker("pt_BR");

        var phone = new PhoneNumber(faker.Person.Phone);

        var newUser = new UserEntity(
            faker.Person.FirstName,
            faker.Person.LastName,
            EGender.Male,
            ENotificationType.WhatsApp,
            email,
            phone,
            Password.ComputeSha256Hash("@G21r03a1985"),
            RoleUserAuth(),
            new DateTime(1990, 1, 1));

        return newUser;
    }

    public static UserEntity InsertExistingData()
    {
        var faker = new Faker("pt_BR");

        var email = new Email("fulanodetal@teste.com.br");
        var phone = new PhoneNumber(faker.Person.Phone);

        var newUser = new UserEntity(
            faker.Person.FirstName,
            faker.Person.LastName,
            EGender.Male,
            ENotificationType.WhatsApp,
            email,
            phone,
            Password.ComputeSha256Hash("@G21r03a1985"),
            RoleUserAuth(),
            new DateTime(1990, 1, 1));

        return newUser;
    }
    #endregion

    #region CreateUserCommand
    public static CreateUserCommand CreateUserCommand()
    {
        var faker = new Faker("pt_BR");

        var command = new CreateUserCommand()
        {
            FirstName = faker.Person.FirstName,
            LastName = faker.Person.LastName,
            Gender = EGender.Male,
            Notification = ENotificationType.WhatsApp,
            Password = "@G21r03a1985",
            ConfirmPassword = "@G21r03a1985",
            DateOfBirth = new DateTime(1990, 1, 1),
            Email = faker.Person.Email,
            Phone = faker.Person.Phone,
            RoleUserAuth = RoleUserAuth()
        };
        return command;
    }

    public static CreateUserCommand CreateUserInvalidDataCommand()
    {
        var faker = new Faker("pt_BR");

        var command = new CreateUserCommand()
        {
            FirstName = "",
            LastName = "",
            Gender = EGender.Male,
            Notification = ENotificationType.WhatsApp,
            Password = "",
            ConfirmPassword = "",
            DateOfBirth = new DateTime(1990, 1, 1),
            Email = "",
            Phone = "",
            RoleUserAuth = RoleUserAuth()
        };
        return command;
    }

    public static CreateUserCommand CreateUserExistingDataCommand()
    {
        var faker = new Faker("pt_BR");

        var command = new CreateUserCommand()
        {
            FirstName = faker.Person.FirstName,
            LastName = faker.Person.LastName,
            Gender = EGender.Male,
            Notification = ENotificationType.WhatsApp,
            Password = "@G21r03a1985",
            ConfirmPassword = "@G21r03a1985",
            DateOfBirth = new DateTime(1990, 1, 1),
            Email = "fulanodetal@teste.com.br",
            Phone = faker.Person.Phone,
            RoleUserAuth = RoleUserAuth()
        };
        return command;
    }
    #endregion

    #region UpdateUserCommand
    public static UpdateUserCommand UpdateUserCommand(Guid id)
    {
        var faker = new Faker("pt_BR");

        var command = new UpdateUserCommand()
        {
            Id = id,
            FirstName = faker.Person.FirstName,
            LastName = faker.Person.LastName,
            Gender = EGender.Male,
            Notification = ENotificationType.WhatsApp,
            DateOfBirth = new DateTime(1990, 1, 1),
            Phone = faker.Person.Phone
        };
        return command;
    }
    public static UpdateUserCommand UpdateUserInvalidDataCommand(Guid id)
    {
        var faker = new Faker("pt_BR");

        var command = new UpdateUserCommand()
        {
            Id = id,
            FirstName = "",
            LastName = "",
            Gender = EGender.Male,
            Notification = ENotificationType.WhatsApp,
            DateOfBirth = new DateTime(1990, 1, 1),
            Phone = ""
        };
        return command;
    }
    #endregion

    #region UpdatePasswordUserCommand
    public static UpdatePasswordUserCommand UpdatePasswordUserCommand(Guid id)
    {
        var faker = new Faker("pt_BR");

        var command = new UpdatePasswordUserCommand()
        {
            Id = id,
            Password = "@G18u03i1986",
            ConfirmPassword = "@G18u03i1986"
        };
        return command;
    }
    public static UpdatePasswordUserCommand UpdatePasswordUserInvalidCommand(Guid id)
    {
        var faker = new Faker("pt_BR");

        var command = new UpdatePasswordUserCommand()
        {
            Id = id,
            Password = "@G18u03i198",
            ConfirmPassword = "@G18u03i1986"
        };
        return command;
    }
    #endregion

    #region UpdateEmailUserCommand
    public static UpdateEmailUserCommand UpdateEmailUserCommand(Guid id)
    {
        var faker = new Faker("pt_BR");

        var command = new UpdateEmailUserCommand()
        {
            Id = id,
            Email = faker.Person.Email
        };
        return command;
    }

    public static UpdateEmailUserCommand UpdateEmailUserCommand(Guid id, string email)
    {
        var faker = new Faker("pt_BR");

        var command = new UpdateEmailUserCommand()
        {
            Id = id,
            Email = email
        };
        return command;
    }

    public static UpdateEmailUserCommand UpdateEmailUserInvalidCommand(Guid id)
    {
        var faker = new Faker("pt_BR");

        var command = new UpdateEmailUserCommand()
        {
            Id = id,
            Email = "teste"
        };
        return command;
    }
    #endregion

    public static List<string> RoleUserAuth()
    => new List<string>
        {
            ERole.AdminCommand.ToString(),
            ERole.AdminQuery.ToString(),

            ERole.RegisterCommand.ToString(),
            ERole.RegisterQuery.ToString(),

            ERole.BasketCommand.ToString(),
            ERole.BasketQuery.ToString(),

            ERole.CatalogCommand.ToString(),
            ERole.CatalogQuery.ToString(),

            ERole.EmployeeCommand.ToString(),
            ERole.EmployeeQuery.ToString(),

            ERole.IdentityCommand.ToString(),
            ERole.IdentityQuery.ToString(),

            ERole.OrderingCommand.ToString(),
            ERole.OrderingQuery.ToString(),

            ERole.PaymentCommand.ToString(),
            ERole.PaymentQuery.ToString(),

            ERole.WebhooksCommand.ToString(),
            ERole.WebhooksQuery.ToString(),
        };
}
