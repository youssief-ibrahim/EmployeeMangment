using System.Threading.Tasks;
using EmployeeMangment.Models;
using EmployeeMangment.Reposatory;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMangment.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IGnericReposatory<Employee> employeeRepo;
        private readonly IGnericReposatory<Department> departmentRepo;
        public EmployeeController(IGnericReposatory<Employee> employeeRepo, IGnericReposatory<Department> departmentRepo)
        {
            this.employeeRepo = employeeRepo;
            this.departmentRepo = departmentRepo;
        }
        public async Task<IActionResult> Index()
        {
            var res= await employeeRepo.GetAllAsync();
            return View(res);
        }

    }
}
