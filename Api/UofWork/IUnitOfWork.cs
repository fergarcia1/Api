using Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.UofWork
{
    public interface IUnitOfWork : IDisposable
    {
        ILibrosRepo libros { get; }
        IAutoresRepo autores { get; }
        void Save();
    }
}
