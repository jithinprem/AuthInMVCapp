namespace StudentCourseWithAuth
{
    public interface IRepository<T>
    {
        public T[] GetAll();
        public T GetById(int id);
        public void Add(T entity);
        public void Delete(int id);
        public void Update(T entity);

    }
}
