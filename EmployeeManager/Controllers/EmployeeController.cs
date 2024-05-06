using AutoMapper;
using EmployeeManager.Contracts;
using EmployeeManager.Entities.DTO;
using EmployeeManager.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Controllers
{
    //[Route("api/v1/departments")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILoggerManager logger;
        private readonly IRepositoryWrapper repository;
        private readonly IMapper mapper;

        public EmployeeController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await repository.Employee.GetAllEmployeesAsync();
                logger.LogInfo("Fetched all employees from database.");

                var employeeResult = mapper.Map<IEnumerable<EmployeeWithDetailsDto>>(employees);
                return Ok(employeeResult);
            }
            catch(Exception ex)
            {
                logger.LogError($"Something went wrong in GetAllEmployees action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id:guid}", Name ="EmployeeById")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            try
            {
                var employee = await repository.Employee.GetEmployeeByIdAsync(id);
                if (employee == null)
                {
                    logger.LogError($"Employee with ID:{id} has not found in the database.");
                    return NotFound($"No Employee record found for ID {id}");
                }

                logger.LogInfo($"Fetched employee with ID: {id}");
                var employeeResult = mapper.Map<EmployeeDto>(employee);
                return Ok(employeeResult);
            }
            catch(Exception ex )
            {
                logger.LogError($"Something went wrong in GetEmployeeById action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id:guid}/department")]
        public async Task<IActionResult> GetEmployeeWithDetails(Guid id)
        {
            try
            {
                var employee = await repository.Employee.GetEmployeeWithDetailsAsync(id);

                if (employee == null)
                {
                    logger.LogError($"Employee with ID: {id} has not found in database.");
                    return NotFound($"No Employee record found for ID {id}");
                }

                logger.LogInfo($"Fetched employee with ID: {id}");
                var employeeResult = mapper.Map<EmployeeWithDetailsDto>(employee);
                return Ok(employeeResult);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong in GetEmployeeById action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateDto employee)
        {
            try
            {
                if (employee == null)
                {
                    logger.LogError("Employee object sent from client is null.");
                    return BadRequest("Employee object is null");
                }

                if (!ModelState.IsValid)
                {
                    logger.LogError("Employee object sent from client is invalid.");
                    return BadRequest("Employee object is invalid");
                }

                var employeeEntity = mapper.Map<Employee>(employee);

                repository.Employee.CreateEmployee(employeeEntity);
                await repository.SaveAsync();

                var createdEmployee = mapper.Map<EmployeeDto>(employeeEntity);

                return CreatedAtRoute("EmployeeById", new { id = createdEmployee.Guid }, createdEmployee);
            }
            catch (Exception e)
            {

                logger.LogError($"Something went wrong in CreateEmployee action: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] EmployeeUpdateDto employee)
        {
            try
            {
                if (employee == null)
                {
                    logger.LogError("Employee object sent from client is null.");
                    return BadRequest("Employee object is null");
                }

                if (!ModelState.IsValid)
                {
                    logger.LogError("Employee object sent from client is invalid.");
                    return BadRequest("Employee object is invalid");
                }

                var employeeEntity = await repository.Employee.GetEmployeeByIdAsync(id);
                if (employeeEntity == null)
                {
                    logger.LogError($"Employee with ID: {id} has not found in database.");
                    return NotFound($"No Employee record found for ID {id}");
                }

                mapper.Map(employee, employeeEntity);

                repository.Employee.UpdateEmployee(employeeEntity);
                await repository.SaveAsync();

                var updatedEmployee = mapper.Map<EmployeeDto>(employeeEntity);

                return AcceptedAtRoute("EmployeeById", new { id = updatedEmployee.Guid }, updatedEmployee);
            }
            catch (Exception e)
            {

                logger.LogError($"Something went wrong in UpdateEmployee action: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            try
            {
                var employee = await repository.Employee.GetEmployeeByIdAsync(id);
                if (employee == null)
                {
                    logger.LogError($"Employee with ID: {id} has not found in database.");
                    return NotFound($"No Employee record found for ID {id}");
                }

                repository.Employee.DeleteEmployee(employee);
                await repository.SaveAsync();

                return NoContent();
            }
            catch (Exception e)
            {
                logger.LogError($"Something went wrong in DeleteEmployee action: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}
