using EmployeeData.DAL;
using EmployeeData.Models;
using EmployeeData.Models.DBEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                //SingleOrDefault return Single row of data
                var employee = _context.Employees.SingleOrDefault(x => x.Id == Id);
                if (employee != null)
                {
                    var employeeview = new EmployeeViewModel()
                    {
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Email = employee.Email,
                        Salary = employee.Salary,
                        DateofBirth = employee.DateofBirth,
                        Id = employee.Id
                    };
                    //passing emlopyeemodel to UI
                    return View(employeeview);
                }
                else
                {
                    TempData["errorMessage"] = $"Employee Details not avilable with this Id:{Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
            
           
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        FirstName = emp.FirstName,
                        Id = emp.Id,
                        LastName = emp.LastName,
                        Email = emp.Email,
                        Salary = emp.Salary,
                        DateofBirth = emp.DateofBirth


                    };
                    _context.Employees.Update(employee);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Employee details updated succesfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model data is invalid!";
                    return View(); /*View itself same page*/
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }
           
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                //SingleOrDefault return Single row of data
                var employee = _context.Employees.SingleOrDefault(x => x.Id == Id);
                if (employee != null)
                {
                    var employeeview = new EmployeeViewModel()
                    {
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Email = employee.Email,
                        Salary = employee.Salary,
                        DateofBirth = employee.DateofBirth,
                        Id = employee.Id
                    };
                    //passing emlopyeemodel to UI
                    return View(employeeview);
                }
                else
                {
                    TempData["errorMessage"] = $"Employee Details not avilable with this Id:{Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }


        }


        [HttpPost]
        public IActionResult Delete (EmployeeViewModel emp) {

            try
            {
                var employee = _context.Employees.SingleOrDefault(x => x.Id == emp.Id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Employee Deleted successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Employee Details not avilable with this Id:{emp.Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
                
        }
    }
}
