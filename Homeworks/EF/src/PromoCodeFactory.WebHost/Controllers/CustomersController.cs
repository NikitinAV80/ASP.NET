using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.WebHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models.Customer;

namespace PromoCodeFactory.WebHost.Controllers;

/// <summary>
/// Клиенты
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IRepository<Customer> _customerRepository;
    private readonly IMapper _mapper;

    
    public CustomersController(IRepository<Customer> customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    /// <summary>
    ///     Получить данные всех покупателей.
    /// </summary>
    /// <returns>Список покупателей <see cref="CustomerShortResponse"/></returns>
    [HttpGet]
    [ProducesResponseType(typeof(CustomerShortResponse) ,StatusCodes.Status200OK)]
    public async Task<ActionResult<CustomerShortResponse>> GetCustomersAsync()
    {
        var entities = await _customerRepository.GetAllAsync(HttpContext.RequestAborted);
        var customers = _mapper.Map<List<CustomerShortResponse>>(entities);

        return Ok(customers);
    }

    /// <summary>
    ///     Получить данные клиента вместе с выданными ему промокодами.
    /// </summary>
    /// <param name="id">Идентификатор клиента.</param>
    /// <returns>Данные клиента<see cref="CustomerResponse"/></returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CustomerResponse>> GetCustomerAsync(Guid id)
    {
        var entity = await _customerRepository.GetByIdAsync(id, HttpContext.RequestAborted);
        
        if(entity == null)
            return NotFound();
        
        var customer = _mapper.Map<CustomerResponse>(entity);
        
        return Ok(customer);
    }

    [HttpPost]
    public Task<IActionResult> CreateCustomerAsync(CreateOrEditCustomerRequest request)
    {
        //TODO: Добавить создание нового клиента вместе с его предпочтениями
        // public class CreateOrEditCustomerRequest
        // {
        //     public string FirstName { get; set; }
        //     public string LastName { get; set; }
        //     public string Email { get; set; }
        //     public List<Guid> PreferenceIds { get; set; }
        // }
        
        throw new NotImplementedException();
    }

    [HttpPut("{id}")]
    public Task<IActionResult> EditCustomersAsync(Guid id, CreateOrEditCustomerRequest request)
    {
        //TODO: Обновить данные клиента вместе с его предпочтениями
        // public class CreateOrEditCustomerRequest
        // {
        //     public string FirstName { get; set; }
        //     public string LastName { get; set; }
        //     public string Email { get; set; }
        //     public List<Guid> PreferenceIds { get; set; }
        // }
        
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Удаление клиента вместе с выданными ему промокодами.
    /// </summary>
    /// <param name="id">Идентификатор клиента.</param>
    /// <returns></returns>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        var result = await _customerRepository.DeleteAsync(id, HttpContext.RequestAborted);

        return result 
            ? NoContent() 
            : NotFound();
    }
}