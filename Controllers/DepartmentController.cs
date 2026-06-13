using EmployeeMangment.Models;
using EmployeeMangment.Reposatory;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMangment.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IGnericReposatory<Department> departmentRepo;
        public DepartmentController(IGnericReposatory<Department> departmentRepo)
        {
            this.departmentRepo = departmentRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
