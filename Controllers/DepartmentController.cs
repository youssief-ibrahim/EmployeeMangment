using System.Threading.Tasks;
using EmployeeMangment.Models;
using EmployeeMangment.Reposatory;
using EmployeeMangment.ViewModel;
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
        public async Task<IActionResult> Index()
        {
            var res =await departmentRepo.GetAllAsync();
            return View(res);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentVM departmentvm)
        {
            if (ModelState.IsValid)
            {
                var department = new Department
                {
                    Name = departmentvm.Name
                };
                await departmentRepo.AddAsync(department);
                await departmentRepo.SaveAsync();
                TempData["Alert"] = "created succfully";
                return RedirectToAction("Index");
            }
            return View(departmentvm);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var res = await departmentRepo.GetById(id);
            var departmentvm = new DepartmentVM
            {
                Id = res.Id,
                Name = res.Name
            };
            return View(departmentvm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentVM departmentvm)
        {
            if (ModelState.IsValid)
            {
               var department= new Department
               {
                   Id = departmentvm.Id,
                   Name = departmentvm.Name
               };
                await departmentRepo.SaveAsync();
                TempData["Alert"] = "updated succfully";
                return RedirectToAction("Index");
            }
            return View(departmentvm);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var res = await departmentRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }
            departmentRepo.Delete(res);
            await departmentRepo.SaveAsync();
            TempData["Alert"] = "deleted succfully";
            return RedirectToAction("Index");
        }
    }
}
