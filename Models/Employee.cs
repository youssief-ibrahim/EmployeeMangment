using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMangment.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string JobTitle { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; } 
    }
}
