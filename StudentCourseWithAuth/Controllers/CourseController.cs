using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentCourseWithAuth.Models;

namespace StudentCourseWithAuth.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IRepository<Course> _repository;

        public CoursesController(IRepository<Course> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {

            return View(_repository.GetAll());
        }

        [Authorize(Policy = "Experience")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Course course)
        {

            _repository.Add(course);
            return View("Index", _repository.GetAll());
        }



        [HttpGet]
        public IActionResult Update(int id)
        {

            var course = _repository.GetById(id);
            return View(course);
        }

        [HttpPost]
        public IActionResult Update(Course course)
        {

            _repository.Update(course);
            return View("Index", _repository.GetAll());
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return View("Index", _repository.GetAll());
        }



    }
}
