using GraphQLProject.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.DataAccess.DAO
{
    public class DepartmentRepository
    {
        private readonly SampleAppDbContext _context;
        public DepartmentRepository(SampleAppDbContext context)
        {
            _context = context;
        }
        public List<Department> GetAllDepartmentOnly()
        {
            return _context.Department.ToList();
        }
        public List<Department> GetAllDepartmentsWithEmployee()
        {
            return _context.Department.Include(d=>d.Employees).ToList();
        }
        public async Task<Department> CreateDepartment(Department department)
        {
            await _context.Department.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }
    }
}
