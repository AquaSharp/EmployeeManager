namespace EmployeeManager.Contracts
{
    public interface IRepositoryWrapper
    {
        IEmployeeRepository Employee { get; }
        IDepartmentRepository Department { get; }
        Task SaveAsync();
    }
}
