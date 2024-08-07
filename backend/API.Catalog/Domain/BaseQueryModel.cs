﻿using poc.core.api.net8.Abstractions;

namespace API.Catalog.Domain;

public abstract class BaseQueryModel : IQueryModel<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
