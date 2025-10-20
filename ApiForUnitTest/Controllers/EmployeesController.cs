using ApiForUnitTest.Interfaces;
using ApiForUnitTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiForUnitTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository repository)
        {
            _employeeRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try 
            {
                var products = await _employeeRepository.GetAllAsync();
                return Ok(products);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var model = await _employeeRepository.GetByIdAsync(id);
                if (model == null)
                    return NotFound();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{name:string}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var model = await _employeeRepository.GetEmployeeByNameAsync(name);
                if (model == null)
                    return NotFound();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee product)
        {
            try
            {
                await _employeeRepository.AddAsync(product);
                await _employeeRepository.SaveAsync();
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Employee model)
        {
            try
            {
                var existing = await _employeeRepository.GetByIdAsync(id);
                if (existing == null)
                    return NotFound();

                existing.FullName = model.FullName;
                existing.EmployeeCode = model.EmployeeCode;
                existing.Email = model.Email;
                existing.Mobile = model.Mobile;
                _employeeRepository.Update(existing);
                await _employeeRepository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existing = await _employeeRepository.GetByIdAsync(id);
                if (existing == null)
                    return NotFound();

                _employeeRepository.Delete(existing);
                await _employeeRepository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
