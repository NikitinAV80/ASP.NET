using System;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.Core.Domain.Administration;

public class Employee : BaseEntity
{
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string LastName { get; set; }
    
    public string FullName => $"{FirstName} {LastName}";
    
    [MaxLength(30)]
    public string Email { get; set; }
    
    public int AppliedPromoCodesCount { get; set; }
    
    /// <summary>
    ///     Навигационное свойство роль.
    /// </summary>
    public virtual Role Role { get; set; }

    public virtual Guid RoleId { get; set; }
}