using ApiForUnitTest.Models;

namespace ApiForUnitTest.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        //Task<List<Employee>> GetAllEmployeeAsync();
        //Task<Employee?> GetEmployeeByIdAsync(int id);
        Task<Employee?> GetEmployeeByNameAsync(string name);
        //Employee? AddEmployee(Employee employee);
        //Task<Employee?> UpdateEmployeeAsync(int id, Employee employee);
        //Task<Employee?> DeleteEmployeeAsync(int id);
    }
}
