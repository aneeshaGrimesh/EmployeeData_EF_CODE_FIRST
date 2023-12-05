using EmployeeData.DAL;
using EmployeeData.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeData.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeDBContext _context;
        public EmployeeController(EmployeeDBContext context)
        {
            this._context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var employee = _context.Employees.ToList();
            List<EmployeeViewModel> employeelIst = new List<EmployeeViewModel>();
            if (employee != null )
            {
              
                foreach(var emp in employee)
                {
                    var EmployeeViewModel = new EmployeeViewModel()
                    {
                        Id = emp.Id,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        DateofBirth = emp.DateofBirth,
                        Salary = emp.Salary,
                        Email = emp.Email,
                        
                    };
                    employeelIst.Add(EmployeeViewModel);
                }
                return View(employeelIst);
            }
            return View(employeelIst);
        }
    }
}
