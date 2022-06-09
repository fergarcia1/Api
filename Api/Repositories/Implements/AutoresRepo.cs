
using Api.Entities;
using Api.Context;
using Microsoft.EntityFrameworkCore;
using Api.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Api.Repositories.Implements
{
    public class AutoresRepo : GenericRepository<Autor>, IAutoresRepo
    {
        public AutoresRepo(ApplicationDBContext db) : base(db)
        {
        }

        public IEnumerable<Autor> GetAutoresYLibros()
        {
            var aux = _db.Autor.Include(x => x.Libros).ToList();
            return aux;
        }

        public Autor GetAutorYLibros(int id)
        {
            var autor = _db.Autor.Where(x => x.Id == id).Include(x => x.Libros).FirstOrDefault();
            return autor;

        }
    }
}