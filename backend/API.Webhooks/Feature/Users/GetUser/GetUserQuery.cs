﻿using MediatR;
using poc.core.api.net8.Response;

namespace API.Webhooks.Feature.Users.GetUser;

public class GetUserQuery : IRequest<ApiResult<List<UserQueryModel>>>
{
    public GetUserQuery()
    {
    }
}
