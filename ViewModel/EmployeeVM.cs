namespace EmployeeMangment.ViewModel
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string JobTitle { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }

        public int DepartmentId { get; set; }
    }
}
