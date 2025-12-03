using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLProject.DataAccess.Entity
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }
        [Required]
        public string? Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
