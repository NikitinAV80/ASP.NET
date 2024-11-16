namespace PromoCodeFactory.WebHost.Models;

public record UpdateEmployeeDto
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public int AppliedPromoCodesCount { get; init; }
}