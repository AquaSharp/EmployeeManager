using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.Entities.DTO
{
    public class DepartmentCreateDto
    {
        [Required(ErrorMessage = "Department name is required")]
        public string Name { get; set; }    
    }
}
