using Api.Context;
using Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Repositories.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDBContext _db;

        public GenericRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public void Delete(int? id)
        {
            var entity = GetById(id);
            if (entity == null)
                throw new Exception("No se encontro objeto");
            _db.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public T GetById(int? id)
        {
            var aux = _db.Set<T>().Find(id);
            return aux;
        }

        public void Insert(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
        }
    }
}