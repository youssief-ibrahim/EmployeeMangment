using System.Threading.Tasks;
using EmployeeMangment.Models;
using EmployeeMangment.Reposatory;
using EmployeeMangment.ViewModel;
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
            var res = await employeeRepo.GetAllwithinclude(e=>e.Department);
            return View(res);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["Departments"] = await departmentRepo.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee
                {
                    FullName = employeeVM.FullName,
                    Email = employeeVM.Email,
                    MobileNumber = employeeVM.MobileNumber,
                    JobTitle = employeeVM.JobTitle,
                    HireDate = employeeVM.HireDate,
                    IsActive = employeeVM.IsActive,
                    DepartmentId = employeeVM.DepartmentId
                };
                await employeeRepo.AddAsync(employee);
                await employeeRepo.SaveAsync();
                TempData["Alert"] = "created succfully";
                return RedirectToAction("Index");
            }
            ViewData["Departments"] = await departmentRepo.GetAllAsync();
            return View(employeeVM);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var res = await employeeRepo.GetById(id);
            if(res == null)
            {
                return NotFound();
            }
            ViewData["Departments"] = await departmentRepo.GetAllAsync();
            var empvm = new EmployeeVM
            {
                Id = res.Id,
                FullName = res.FullName,
                Email = res.Email,
                MobileNumber = res.MobileNumber,
                JobTitle = res.JobTitle,
                HireDate = res.HireDate,
                IsActive = res.IsActive,
                DepartmentId = res.DepartmentId
            };
            return View(empvm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeVM employeevm)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Id = employeevm.Id,
                    FullName = employeevm.FullName,
                    Email = employeevm.Email,
                    MobileNumber = employeevm.MobileNumber,
                    JobTitle = employeevm.JobTitle,
                    HireDate = employeevm.HireDate,
                    IsActive = employeevm.IsActive,
                    DepartmentId = employeevm.DepartmentId
                };
                employeeRepo.Update(employee);
                await employeeRepo.SaveAsync();
                TempData["Alert"] = "updated succfully";
                return RedirectToAction("Index");
            }
            ViewData["Departments"] = await departmentRepo.GetAllAsync();
            return View(employeevm);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var res = await employeeRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }
            employeeRepo.Delete(res);
            await employeeRepo.SaveAsync();
            TempData["Alert"] = "deleted succfully";
            return RedirectToAction("Index");
        }
    }
}
