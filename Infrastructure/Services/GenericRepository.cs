using Application.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entity;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _entity = _context.Set<T>();    
        }
        
        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.ToList();
        }

        public T GetById(object id)
        {
            return _entity.Find(id);
        }

        public void Insert(T obj)
        {
            _entity.Add(obj);
        }

        public void Update(T obj)
        {
            _entity.Update(obj);
        }

        public void Delete(object id)
        {
            var entity = _entity.Find(id);
            _entity.Remove(entity);
        }
    }
}
