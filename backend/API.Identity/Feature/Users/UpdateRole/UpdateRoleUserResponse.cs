﻿using poc.core.api.net8;

namespace API.Identity.Feature.Users.UpdateRole;

public class UpdateRoleUserResponse : BaseResponse
{
    public UpdateRoleUserResponse(Guid id) => Id = id;
    public Guid Id { get; }
}
