using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Entities
{
    public class Libros
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public int AutorId { get; set; }
        public Autor? Autor { get; set; }
    }
}
