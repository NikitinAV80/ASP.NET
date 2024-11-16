using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.Controllers;

/// <summary>
///     Сотрудники
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IRepository<Employee> _employeeRepository;

    public EmployeesController(IRepository<Employee> employeeRepository)
    {
        _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
    }

    /// <summary>
    ///     Получить данные всех сотрудников
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<EmployeeShortResponse>> GetEmployeesAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();

        var employeesModelList = employees.Select(x =>
            new EmployeeShortResponse
            {
                Id = x.Id,
                Email = x.Email,
                FullName = x.FullName,
            }).ToList();

        return employeesModelList;
    }

    /// <summary>
    ///     Получить данные сотрудника по Id
    /// </summary>
    /// <param name="id">Идентификатор сотрудника</param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(EmployeeShortResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<EmployeeResponse>> GetEmployeeByIdAsync(Guid id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);

        if (employee == null)
            return NotFound();

        var employeeModel = new EmployeeResponse
        {
            Id = employee.Id,
            Email = employee.Email,
            Roles = employee.Roles.Select(x => new RoleItemResponse
            {
                Name = x.Name,
                Description = x.Description
            }).ToList(),
            FullName = employee.FullName,
            AppliedPromoCodesCount = employee.AppliedPromoCodesCount
        };

        return employeeModel;
    }
        
    /// <summary>
    ///     Создать сотрудника
    /// </summary>
    /// <param name="employeeDto">Данные сотрудника <see cref="CreateEmployeeDto"/></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult> CreateEmployeeAsync(CreateEmployeeDto employeeDto)
    {
        var employee = new Employee
        {
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            Email = employeeDto.Email,
            AppliedPromoCodesCount = employeeDto.AppliedPromoCodesCount,
            Roles = []
        };
            
        var id = await _employeeRepository.CreateAsync(employee);

        return Ok(id);
    }

    /// <summary>
    ///     Обновить данные сотрудника
    /// </summary>
    /// <param name="id">Идентификатор сотрудника</param>
    /// <param name="employeeDto">Обновленные данные сотрудника</param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(EmployeeShortResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult> UpdateEmployeeAsync(Guid id, UpdateEmployeeDto employeeDto)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
            
        if (employee == null)
            return NotFound();
            
        var updateEmployee = new Employee
        {
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            Email = employeeDto.Email,
            AppliedPromoCodesCount = employeeDto.AppliedPromoCodesCount,
            Id = employee.Id,
            Roles = employee.Roles
        };
            
        await _employeeRepository.UpdateAsync(id, updateEmployee);
            
        return NoContent();
    }
        
    /// <summary>
    ///     Удалить сотрудника
    /// </summary>
    /// <param name="id">Идентификатор сотрудника</param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> DeleteEmployeeByIdAsync(Guid id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
            
        if (employee == null)
            return NotFound();
            
        await _employeeRepository.DeleteAsync(id);
            
        return NoContent();
    }
}