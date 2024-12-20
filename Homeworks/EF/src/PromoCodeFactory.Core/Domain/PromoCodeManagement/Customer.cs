using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement;

public class Customer : BaseEntity
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
    
    /// <summary>
    ///     Навигационное свойство предпочтения.
    /// </summary>
    public virtual List<Preference> Preferences { get; set; }
    
    /// <summary>
    ///     Навигационное свойство промокод.
    /// </summary>
    public virtual List<PromoCode> PromoCodes { get; set; }
}