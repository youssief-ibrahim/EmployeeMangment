using System.ComponentModel.DataAnnotations;

namespace EmployeeMangment.ViewModel
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression(@"^01[0125][0-9]{8}$",ErrorMessage = "Invalid mobile number.")]
        public string MobileNumber { get; set; }
        public string JobTitle { get; set; }
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }=false;
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
    }
}
