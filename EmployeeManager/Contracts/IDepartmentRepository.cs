using EmployeeManager.Entities.Models;

namespace EmployeeManager.Contracts
{
    public interface IDepartmentRepository : IRepositoryBase<Department>
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(Guid guid);
        Task<Department> GetDepartmentWithDetailsAsync(Guid guid);
        void CreateDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(Department department);
    }
}
