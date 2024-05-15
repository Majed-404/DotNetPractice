namespace Application.Services
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllWithRelated(string[] includes = null);

        IEnumerable<T> GetAllForPaging(int take, int skip, string[] includes = null);

        Task<T> GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}
