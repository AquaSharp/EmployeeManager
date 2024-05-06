namespace EmployeeManager.Entities.DTO
{
    public class DepartmentWithEmployees: DTimestamps
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }

        public IEnumerable<EmployeeDto> Employees { get; set; }
    }
}
