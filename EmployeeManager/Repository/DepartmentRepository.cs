using EmployeeManager.Contracts;
using EmployeeManager.Entities;
using EmployeeManager.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Repository
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        private readonly AppDbContext repositoryContext;

        public DepartmentRepository(AppDbContext repositoryContext) : base(repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }
        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await FindAll().ToListAsync();
        }
        public Task<Department> GetDepartmentByIdAsync(Guid guid)
        {
            throw new NotImplementedException();
        }
        public void CreateDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public void DeleteDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetDepartmentWithDetailsAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public void UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
