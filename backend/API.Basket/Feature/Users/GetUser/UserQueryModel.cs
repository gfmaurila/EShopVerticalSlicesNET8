﻿using API.Basket.Domain;
using poc.core.api.net8.Enumerado;

namespace API.Basket.Feature.Users.GetUser;

public class UserQueryModel : BaseQueryModel
{
    public string FirstName { get; init; }

    public string LastName { get; init; }

    public EGender Gender { get; init; }

    public DateTime DateOfBirth { get; init; }

    public string Email { get; init; }
    public string Phone { get; init; }

    //public string Password { get; init; }

    public List<string> RoleUserAuth { get; init; } = new List<string>();
}
