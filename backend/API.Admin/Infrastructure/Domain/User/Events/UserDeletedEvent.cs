﻿using poc.core.api.net8.Enumerado;

namespace API.Admin.Infrastructure.Domain.User.Events;

/// <summary>
/// Evento que representa uma atualização de um entidade.
/// </summary>
public class UserDeletedEvent : UserBaseEvent
{
    public UserDeletedEvent(Guid id, string firstName, string lastName, EGender gender, ENotificationType notification, string email, string phone, string password, List<string> role, DateTime dateOfBirth) :
        base(id, firstName, lastName, gender, notification, email, phone, password, role, dateOfBirth)
    {
    }
}