using System;
using System.Collections.Generic;

namespace PromoCodeFactory.WebHost.Models;

public record EmployeeResponse
{
    public Guid Id { get; init; }
    public string FullName { get; init; }
    public string Email { get; init; }
    public List<RoleItemResponse> Roles { get; init; }
    public int AppliedPromoCodesCount { get; init; }
}