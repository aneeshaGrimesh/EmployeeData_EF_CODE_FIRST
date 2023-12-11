using EmployeeData.DAL;
using EmployeeData.Models;
using EmployeeData.Models.DBEntity;
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
            try
            {
                var employee = _context.Employees.ToList();
                List<EmployeeViewModel> employeelIst = new List<EmployeeViewModel>();
                if (employee != null)
                {

                    foreach (var emp in employee)
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
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }// return get employee page view with employee view model


        [HttpGet]
        public IActionResult Create() // return Create page view with employee view model
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeedata)
        {
            try
            {
                if (ModelState.IsValid)// validate model values from ui 
                {
                    var employee = new Employee() //this object will communicate to DB
                    {
                        FirstName = employeedata.FirstName,
                        LastName = employeedata.LastName,
                        DateofBirth = employeedata.DateofBirth,
                        Email = employeedata.Email,
                        Salary = employeedata.Salary
                    };
                    _context.Employees.Add(employee);
                    _context.SaveChanges();//built in function
                    TempData["SuccessMessage"] = "Employee created successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model data not valid";
                    return View();// same page
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
           
           
        }
    }
}
