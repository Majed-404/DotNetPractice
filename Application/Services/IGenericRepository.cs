using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);

        Task<T> FindByNameAsync(Expression<Func<T, bool>> match, string[] includes = null);

        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}
