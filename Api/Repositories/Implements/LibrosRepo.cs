using Api.Context;
using Api.Entities;
using Api.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Api.Repositories.Implements
{
    public class LibrosRepo : GenericRepository<Libros>, ILibrosRepo
    {
        public LibrosRepo(ApplicationDBContext db) : base(db)
        {

        }

        public IEnumerable<Libros> GetLibrosYAutores()
        {
            var aux = _db.Libros.Include(x => x.Autor).ToList();
            return aux;
        }

        public Libros GetLibroYAutor(int id)
        {
            var libro = _db.Libros.Where(x => x.Id == id).Include(x => x.Autor).FirstOrDefault();
            return libro;
        }
    }
}