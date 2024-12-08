using Microsoft.AspNetCore.Mvc;
using System.Linq;
using sampleproject.Models;

namespace sampleproject.Controllers
{
    public class EmpController : Controller
    {
        MyContext context;

        public EmpController()
        {
            context = new MyContext();
        }

        // READ: List all employees
        public IActionResult Index()
        {
            var emplist = context.employees.ToList();
            return View(emplist);
        }

        // CREATE: Get method to render the create form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE: Post method to handle form submission
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid && employee.Name != "tmp")
            {
                context.employees.Add(employee);
                context.SaveChanges();

                return RedirectToAction("Index"); // Redirect to list after adding
            }

            return View(employee);
        }

        // UPDATE: Get method to render the edit form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = context.employees.FirstOrDefault(e => e.id == id);

            if (employee == null)
            {
                return NotFound(); // Return 404 if not found
            }

            return View(employee);
        }

        // UPDATE: Post method to handle form submission
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var existingEmployee = context.employees.FirstOrDefault(e => e.id == employee.id);

                if (existingEmployee != null)
                {
                    existingEmployee.Name = employee.Name;
                    existingEmployee.Salary = employee.Salary;
                    existingEmployee.phoneNumber = employee.phoneNumber;
                    existingEmployee.age = employee.age;
                    existingEmployee.image = employee.image;

                    context.SaveChanges();
                    return RedirectToAction("Index"); // Redirect to list after editing
                }
            }

            return View(employee);
        }

        // DELETE: Get method to confirm deletion
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = context.employees.FirstOrDefault(e => e.id == id);

            if (employee == null)
            {
                return NotFound(); // Return 404 if not found
            }

            return View(employee);
        }

        // DELETE: Post method to handle deletion
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = context.employees.FirstOrDefault(e => e.id == id);

            if (employee != null)
            {
                context.employees.Remove(employee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        // DETAILS: View an employee's details
        public IActionResult Details(int id)
        {
            var employee = context.employees.FirstOrDefault(e => e.id == id);

            if (employee == null)
            {
                return NotFound(); // Return 404 if not found
            }

            return View(employee);
        }

        [HttpGet]
        public IActionResult Search(string searchTerm)
        {
            var employees = context.employees
                .Where(e => string.IsNullOrEmpty(searchTerm) || e.Name.Contains(searchTerm))
                .ToList();

            return PartialView("_EmployeeList", employees); // Returns a partial view with the filtered employees
        }

    }
}
