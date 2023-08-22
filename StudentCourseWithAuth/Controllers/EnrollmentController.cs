using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentCourseWithAuth.Models;

namespace StudentCourseWithAuth.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class EnrollmentsController : Controller
    {
        private IRepository<Enrollment> _repository;
        public EnrollmentsController(IRepository<Enrollment> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Enrollment enrollment)
        {
            _repository.Add(enrollment);
            return View("Index", _repository.GetAll());
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var student = _repository.GetById(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Enrollment enrollment)
        {
            _repository.Update(enrollment);
            return View("Index", _repository.GetAll());
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return View("Index", _repository.GetAll());
        }
    }
}
