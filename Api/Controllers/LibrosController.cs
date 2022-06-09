using Api.Context;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.UofWork;
using System.Collections.Generic;
using Api.Authorization;

namespace ApiRestFull.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        public readonly IUnitOfWork context;
        public LibrosController(IUnitOfWork context)
        {
            this.context = context;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<Libros>> Get()
        {
            var libros = context.libros.GetLibrosYAutores();
            return Ok(libros);
        }
        [Authorize(Role.User, Role.Admin)]
        [HttpPost]
        public ActionResult Post([FromBody] Libros libro
            )
        {
            context.libros.Insert(libro);
            context.Save();
            return new CreatedAtRouteResult("Autor", new { id = libro.Id }, libro);
        }
        [Authorize(Role.User, Role.Admin)]
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Libros libro, int id)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }
            context.libros.Update(libro);
            context.Save();
            return Ok();

        }
        [Authorize(Role.Admin)]
        [HttpDelete("{numero}")]
        public ActionResult<Libros> Delete(int numero)
        {
            var libro = context.libros.GetById(numero);
            if (libro == null)
            {
                return NotFound();
            }

            context.libros.Delete(numero);
            context.Save();

            return Ok(libro);

        }

        [HttpGet("{id}")]
        public ActionResult<Libros> FindID(int id)
        {
            var libro = context.libros.GetLibroYAutor(id);
            if (libro == null)
            {
                return NotFound();
            }
            return Ok(libro);
        }

    }
}
