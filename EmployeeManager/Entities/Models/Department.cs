using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManager.Entities.Models
{
    [Table("Departments")]
    public class Department: ModelBase
    {
        [Key]
        [Column("DepartmentId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("DepartmentGuid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; } = new Guid();

        [Column("DepartmentName")]
        [Required(ErrorMessage ="DepartmentName is required")]
        public string Name { get; set; }
        
        public ICollection<Employee> Employees { get; set; }
    }
}
