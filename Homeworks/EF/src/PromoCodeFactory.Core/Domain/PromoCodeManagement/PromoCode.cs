using System;
using System.ComponentModel.DataAnnotations;
using PromoCodeFactory.Core.Domain.Administration;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement;

public class PromoCode : BaseEntity
{
    [Required]
    [MaxLength(30)]
    public string Code { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string ServiceInfo { get; set; }
    
    public DateTime BeginDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    [MaxLength(30)]
    public string PartnerName { get; set; }
    
    /// <summary>
    ///     Навигационное свойство работник.
    /// </summary>
    public virtual Employee? PartnerManager { get; set; }
    public Guid? PartnerManagerId { get; set; }
    
    /// <summary>
    ///     Навигационное свойство предпочтение.
    /// </summary>
    public virtual Preference? Preference { get; set; }
    public Guid? PreferenceId { get; set; }
    
    /// <summary>
    ///     Навигационное свойство покупатель.
    /// </summary>
    public virtual Customer? Customer { get; set; }
    public Guid? CustomerId { get; set; }    
}