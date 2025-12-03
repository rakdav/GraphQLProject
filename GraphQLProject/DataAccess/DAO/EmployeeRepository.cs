using GraphQLProject.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.DataAccess.DAO
{
    public class EmployeeRepository
    {
        private readonly SampleAppDbContext _context;
        public EmployeeRepository(SampleAppDbContext context)
        {
            _context = context;
        }
        public List<Employee> GetEmployees()
        {
            return _context.Employee.ToList();
        }
        public Employee GetEmployeeById(int id)
        {
            var employee= _context.Employee.Include(e=>e.Department).Where(e=>e.EmployeeId==id). FirstOrDefault();
            if(employee!=null) return employee;
            return null!;
        }
        public List<Employee> GetEmployeeWithDepartment()
        {
            return _context.Employee.Include(e => e.Department).ToList();
        }
        public async Task<Employee> CreateEmployee(Employee emp)
        {
            await _context.Employee.AddAsync(emp);
            await _context.SaveChangesAsync();
            return emp;
        }
    }
}
