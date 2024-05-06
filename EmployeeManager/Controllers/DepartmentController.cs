using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManager.Contracts;
using EmployeeManager.Entities.DTO;
using EmployeeManager.Entities.Models;
using EmployeeManager.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Controllers
{
    //[Route("api/v1/departments")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ILoggerManager logger;
        private readonly IMapper mapper;
        private readonly IRepositoryWrapper repository;

        public DepartmentController(ILoggerManager logger, IMapper mapper, IRepositoryWrapper repository )
        {
            this.logger = logger;
            this.mapper = mapper;
            this.repository = repository;
          
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments(bool minimal)
        {
            try
            {
                var departments = await repository.Department.GetAllDepartmentsAsync();
                logger.LogInfo("Fetched all departments from the database");

                if (minimal)
                {
                    var departmentMinimalResult = mapper.Map<IEnumerable<DepartmentMinimalDto>>(departments);
                    return Ok(departmentMinimalResult);
                }

                var departmentResult = mapper.Map<IEnumerable<DepartmentDto>>(departments);
                return Ok(departmentResult);    
            }
            catch(Exception ex)
            {
                logger.LogError($"Something went wrong in GetAllDepartments action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        
    }
}
