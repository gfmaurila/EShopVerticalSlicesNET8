﻿using poc.core.api.net8;

namespace API.Basket.Feature.Users.UpdateRole;

public class UpdateRoleUserResponse : BaseResponse
{
    public UpdateRoleUserResponse(Guid id) => Id = id;
    public Guid Id { get; }
}