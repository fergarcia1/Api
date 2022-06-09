using Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface IAutoresRepo : IGenericRepository<Autor>
    {
        IEnumerable<Autor> GetAutoresYLibros();
        Autor GetAutorYLibros(int id);
    }
}

