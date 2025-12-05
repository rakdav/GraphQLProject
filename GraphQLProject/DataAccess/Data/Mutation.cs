using GraphQLProject.DataAccess.DAO;
using GraphQLProject.DataAccess.Entity;
using HotChocolate.Subscriptions;

namespace GraphQLProject.DataAccess.Data
{
    public class Mutation
    {
        public async Task<Department> CreateDepartment([Service] DepartmentRepository departmentRepository, [Service] ITopicEventSender eventSender,string depName)
        {
            var dep=new Department { Name=depName};
            var createDep=await departmentRepository.CreateDepartment(dep);
            await eventSender.SendAsync("DepartmentCreated", createDep);
            return createDep;
        }
        public async Task<Employee> CreateWithDepartmentId([Service] EmployeeRepository employeeRepository, [Service] ITopicEventSender eventSender,string name,int age,string mail,int depId)
        {
            Employee emp=new Employee
            {
                Name=name,
                Age=age,
                Email=mail,
                DepartmentId=depId
            };
            var createEmp=await employeeRepository.CreateEmployee(emp);
            return createEmp;
        }
        public async Task<Employee> CreateWithDepartmentName([Service] EmployeeRepository employeeRepository, [Service] ITopicEventSender eventSender, string name, int age, string mail, string depName)
        {
            Employee emp = new Employee
            {
                Name = name,
                Age = age,
                Email = mail,
                Department=new Department { Name= depName}
            };
            var createEmp = await employeeRepository.CreateEmployee(emp);
            return createEmp;
        }

    }
}
