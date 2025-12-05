using GraphQLProject.DataAccess.DAO;
using GraphQLProject.DataAccess.Entity;
using HotChocolate.Subscriptions;

namespace GraphQLProject.DataAccess.Data
{
    public class Query
    {
        public List<Employee> AllEmployeeOnly([Service] EmployeeRepository employeeRepository)=>employeeRepository.GetEmployees();
        
        public List<Employee> AllEmployeeWithDepartment([Service] EmployeeRepository employeeRepository) => employeeRepository.GetEmployeeWithDepartment();

        public async Task<Employee> GetEmployerById([Service] EmployeeRepository employeeRepository, [Service] ITopicEventSender eventSender,int id)
        {
            Employee emp=employeeRepository.GetEmployeeById(id);
            await eventSender.SendAsync("ReturnedEmployee", emp);
            return emp;
        }
        public List<Department> AllDepartmentOnly([Service] DepartmentRepository departmentRepository) => departmentRepository.GetAllDepartmentOnly();

        public List<Department> AllDepartmentWithEmployee([Service] DepartmentRepository departmentRepository)=>departmentRepository.GetAllDepartmentsWithEmployee();
    }
}
