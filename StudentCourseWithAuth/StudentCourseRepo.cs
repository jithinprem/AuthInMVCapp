using Microsoft.EntityFrameworkCore;

namespace StudentCourseWithAuth
{
    public class StudentCourseRepo<T> : IRepository<T> where T : class
    {
        private readonly StudentContext _context;

        public StudentCourseRepo(StudentContext context)
        {
            this._context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var row = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(row);
            _context.SaveChanges();
        }

        public T[] GetAll()
        {
            return _context.Set<T>().ToArray();
        }

        public T GetById(int id)
        {
            // you can do some null checking and based on that route it to the specified location
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
