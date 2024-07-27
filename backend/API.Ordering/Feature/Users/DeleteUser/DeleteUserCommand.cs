﻿using MediatR;
using poc.core.api.net8.Response;

namespace API.Ordering.Feature.Users.DeleteUser;

public class DeleteUserCommand : IRequest<ApiResult<DeleteUserResponse>>
{
    public DeleteUserCommand(Guid id) => Id = id;

    public Guid Id { get; private set; }
}