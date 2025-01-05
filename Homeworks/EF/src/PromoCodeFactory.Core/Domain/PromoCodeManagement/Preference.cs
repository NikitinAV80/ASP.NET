using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement;

public class Preference : BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    /// <summary>
    ///     Навигационное свойство покупатели.
    /// </summary>
    public virtual List<Customer> Customers { get; set; }
    
    /// <summary>
    ///     Навигационное свойство промокоды.
    /// </summary>
    public virtual List<PromoCode> PromoCodes { get; set; }
}