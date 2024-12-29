using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models.Promocode;

namespace PromoCodeFactory.WebHost.Controllers;

/// <summary>
///     Промокоды.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class PromocodesController : ControllerBase
{
    private readonly IRepository<PromoCode> _promoCodeRepository;
    private readonly IMapper _mapper;

    public PromocodesController(IRepository<PromoCode> promoCodeRepository, IMapper mapper)
    {
        _promoCodeRepository = promoCodeRepository ?? throw new ArgumentNullException(nameof(promoCodeRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    ///     Получить все промокоды.
    /// </summary>
    /// <returns>Список промокодов <see cref="PromoCodeShortResponse"/></returns>
    [HttpGet]
    [ProducesResponseType(typeof(PromoCodeShortResponse) ,StatusCodes.Status200OK)]
    public async Task<ActionResult<List<PromoCodeShortResponse>>> GetPromoCodesAsync()
    {
        var entities = await _promoCodeRepository.GetAllAsync(HttpContext.RequestAborted);
        var promo = _mapper.Map<List<PromoCodeShortResponse>>(entities);

        return Ok(promo);
    }

    /// <summary>
    ///     Создать промокод и выдать его клиентам с указанным предпочтением.
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public Task<IActionResult> GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeRequest request)
    {
        //TODO: Создать промокод и выдать его клиентам с указанным предпочтением
        throw new NotImplementedException();
    }
}