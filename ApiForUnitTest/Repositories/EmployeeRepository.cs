using ApiForUnitTest.Interfaces;
using ApiForUnitTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiForUnitTest.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ReactjsDbContext context) : base(context) { }

        public async Task<Employee?> GetEmployeeByNameAsync(string name)
        {
            return await _context.Set<Employee>().FirstOrDefaultAsync(x => x.FullName == name);
        }
    }
}
