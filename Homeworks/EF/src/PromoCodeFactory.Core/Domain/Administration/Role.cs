using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.Core.Domain.Administration;

public class Role : BaseEntity
{
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Description { get; set; }
    
    /// <summary>
    /// Навигационное свойство работник.
    /// </summary>
    public virtual Employee? Employee { get; set; }
}