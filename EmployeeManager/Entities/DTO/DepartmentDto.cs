namespace EmployeeManager.Entities.DTO
{
    public class DepartmentDto: DTimestamps
    {
        public long Id { get; set; }    
        public Guid Guid { get; set; }
        public string Name { get; set; }
    }
}
