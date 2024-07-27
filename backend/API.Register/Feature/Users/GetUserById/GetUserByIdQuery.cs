﻿using API.Register.Feature.Users.GetUser;
using MediatR;
using poc.core.api.net8.Response;

namespace API.Register.Feature.Users.GetUserById;


public class GetUserByIdQuery : IRequest<ApiResult<UserQueryModel>>
{
    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; private set; }
}