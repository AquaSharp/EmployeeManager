using EmployeeManager.Contracts;
using EmployeeManager.Entities;

namespace EmployeeManager.Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private readonly AppDbContext repositoryContext;
        private IDepartmentRepository _department;
        private IEmployeeRepository _employee;
        public RepositoryWrapper(AppDbContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null) _employee = new EmployeeRepository(repositoryContext);
                return _employee;
            }
        }

        public IDepartmentRepository Department
        {
            get
            {
                if (_department == null) _department = new DepartmentRepository(repositoryContext);
                return _department;
            }
        }

        public async Task SaveAsync()
        {
            await repositoryContext.SaveChangesAsync();
        }
    }
}
