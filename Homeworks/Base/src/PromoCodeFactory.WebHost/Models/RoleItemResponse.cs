using System;

namespace PromoCodeFactory.WebHost.Models;

public record RoleItemResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
}