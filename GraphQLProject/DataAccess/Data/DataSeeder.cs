using Faker;
using GraphQLProject.DataAccess.Entity;
using System.ComponentModel.DataAnnotations;

namespace GraphQLProject.DataAccess.Data
{
    public static class DataSeeder
    {
        public static void SeedData(SampleAppDbContext db)
        {
            if (!db.Department.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var dep = new Department
                    {
                        Name = Lorem.Sentence()
                    };
                    db.Department.Add(dep);
                    for (int j = 0; j < 5; j++)
                    {
                        var emp = new Employee
                        {
                            Name = Name.FullName(),
                            Email = Faker.Internet.Email(),
                            Age = new Random().Next(18, 70),
                            Department = dep
                        };
                        db.Employee.Add(emp);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
