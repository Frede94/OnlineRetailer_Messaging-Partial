namespace CustomerApi.Data
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetValue(int id);
        T Add(T entity);
        void Update(T entity);
        void Delete(int id);   
    }
}
