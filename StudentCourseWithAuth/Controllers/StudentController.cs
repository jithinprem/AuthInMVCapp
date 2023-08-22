using Microsoft.AspNetCore.Mvc;
using StudentCourseWithAuth.Models;

namespace StudentCourseWithAuth.Controllers
{
    public class StudentsController : Controller
    {
        private IRepository<Student> _repository;
        public StudentsController(IRepository<Student> repository)
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
        public IActionResult Add(Student student)
        {
            _repository.Add(student);
            return View("Index", _repository.GetAll());
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var student = _repository.GetById(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Student student)
        {
            _repository.Update(student);
            return View("Index", _repository.GetAll());
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return View("Index", _repository.GetAll());
        }


    }
}
