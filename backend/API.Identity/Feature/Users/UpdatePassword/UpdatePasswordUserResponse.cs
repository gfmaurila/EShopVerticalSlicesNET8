﻿using poc.core.api.net8;

namespace API.Identity.Feature.Users.UpdatePassword;

public class UpdatePasswordUserResponse : BaseResponse
{
    public UpdatePasswordUserResponse(Guid id) => Id = id;
    public Guid Id { get; }
}
