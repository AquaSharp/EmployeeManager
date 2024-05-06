using AutoMapper;
using EmployeeManager.Entities.DTO;
using EmployeeManager.Entities.Models;

namespace EmployeeManager
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, EmployeeWithDetailsDto>();
            CreateMap<Employee, EmployeeCreateDto>();
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<Employee, EmployeeUpdateDto>();
            CreateMap<EmployeeUpdateDto, Employee>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<Department, DepartmentMinimalDto>();
            CreateMap<Department, DepartmentCreateDto>();
        }
    }
}
