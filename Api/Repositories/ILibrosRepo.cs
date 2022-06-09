using Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface ILibrosRepo : IGenericRepository<Libros>
    {
        IEnumerable<Libros> GetLibrosYAutores();
        Libros GetLibroYAutor(int id);
    }
}

