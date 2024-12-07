using Microsoft.AspNetCore.Mvc;
using System.Linq;
using sampleproject.Models;

namespace sampleproject.Controllers
{
    public class DepController : Controller
    {
        MyContext context;

        public DepController()
        {
            context = new MyContext();
        }

        // READ: List all departments
        public IActionResult Index()
        {
            var deptList = context.departments.ToList();
            return View(deptList);
        }

        // CREATE: Get method to render the create form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE: Post method to handle form submission
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                context.departments.Add(department);
                context.SaveChanges();

                return RedirectToAction("Index"); // Redirect to list after adding
            }

            return View(department);
        }

        // UPDATE: Get method to render the edit form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = context.departments.FirstOrDefault(d => d.id == id);

            if (department == null)
            {
                return NotFound(); // Return 404 if not found
            }

            return View(department);
        }

        // UPDATE: Post method to handle form submission
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                var existingDepartment = context.departments.FirstOrDefault(d => d.id == department.id);

                if (existingDepartment != null)
                {
                    existingDepartment.name = department.name;
                    existingDepartment.phoneNumber = department.phoneNumber;
                    existingDepartment.age = department.age;

                    context.SaveChanges();
                    return RedirectToAction("Index"); // Redirect to list after editing
                }
            }

            return View(department);
        }

        // DELETE: Get method to confirm deletion
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = context.departments.FirstOrDefault(d => d.id == id);

            if (department == null)
            {
                return NotFound(); // Return 404 if not found
            }

            return View(department);
        }

        // DELETE: Post method to handle deletion
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = context.departments.FirstOrDefault(d => d.id == id);

            if (department != null)
            {
                context.departments.Remove(department);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        // DETAILS: View a department's details
        public IActionResult Details(int id)
        {
            var department = context.departments.FirstOrDefault(d => d.id == id);

            if (department == null)
            {
                return NotFound(); // Return 404 if not found
            }

            return View(department);
        }
    }
}
