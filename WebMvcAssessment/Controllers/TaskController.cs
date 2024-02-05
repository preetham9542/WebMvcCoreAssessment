using Microsoft.AspNetCore.Mvc;
using WebMvcAssessment.Models;

namespace WebMvcAssessment.Controllers
{
    public class TaskController : Controller
    {
        static List<WebMvcAssessment.Models.Task> tasks = new List<WebMvcAssessment.Models.Task>()
        {
            new Models.Task {id=1,Title = "Uploading Task",Description = "Upload Successful",DueDate = new DateTime(day:12,month:01,year:2003) },
            new Models.Task {id=2,Title = "Deleting Task",Description = "Delete Successful",DueDate = new DateTime(day:01,month:06,year:2014) },
            new Models.Task {id=3,Title = "Manipulating Task",Description = "Manipulation Successful",DueDate = new DateTime(day:06,month:03,year:2016) }
        };

        public IActionResult Index()
        {
            return View(tasks);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Models.Task());
        }
        [HttpPost]
        public IActionResult Create(Models.Task taskcontent)
        {
            if (taskcontent != null)
            {
                if (ModelState.IsValid)
                {
                    tasks.Add(taskcontent);
                    return RedirectToAction("Index");
                }
            }
            return View(tasks);
        }
        public IActionResult Details(int id)
        {
            var task = tasks.FirstOrDefault(t => t.id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = tasks.FirstOrDefault(t => t.id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(Models.Task updatedTask)
        {
            if (ModelState.IsValid)
            {
                var existingTask = tasks.FirstOrDefault(t => t.id == updatedTask.id);
                if (existingTask != null)
                {
                    existingTask.Title = updatedTask.Title;
                    existingTask.Description = updatedTask.Description;
                    existingTask.DueDate = updatedTask.DueDate;
                    return RedirectToAction("Index");
                }
            }
            return View(updatedTask);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = tasks.FirstOrDefault(t => t.id == id);
            if (task != null)
            {
                tasks.Remove(task);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

    }
}
