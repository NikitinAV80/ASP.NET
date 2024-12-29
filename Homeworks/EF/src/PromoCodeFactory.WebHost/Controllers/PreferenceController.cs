using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models.Preference;

namespace PromoCodeFactory.WebHost.Controllers;

/// <summary>
///     Предпочтения.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class PreferenceController : ControllerBase
{
    private readonly IRepository<Preference> _preferenceRepository;
    private readonly IMapper _mapper;


    public PreferenceController(IRepository<Preference> preferenceRepository, IMapper mapper)
    {
        _preferenceRepository = preferenceRepository ?? throw new ArgumentNullException(nameof(preferenceRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    /// <summary>
    ///     Получить список всех предпочтений.
    /// </summary>
    /// <returns>Список предпочтений <see cref="PreferenceResponse"/></returns>
    [HttpGet]
    [ProducesResponseType(typeof(PreferenceResponse) ,StatusCodes.Status200OK)]
    public async Task<ActionResult<PreferenceResponse>> GetPreferencesAsync()
    {
        var entities = await _preferenceRepository.GetAllAsync(HttpContext.RequestAborted);
        var preferences = _mapper.Map<List<PreferenceResponse>>(entities);

        return Ok(preferences);
    }
}