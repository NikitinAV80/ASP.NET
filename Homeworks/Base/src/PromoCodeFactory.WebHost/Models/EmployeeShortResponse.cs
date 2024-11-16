using System;

namespace PromoCodeFactory.WebHost.Models;

public record EmployeeShortResponse
{
    public Guid Id { get; init; }
    public string FullName { get; init; }
    public string Email { get; init; }
}