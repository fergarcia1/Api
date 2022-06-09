using System;
using Api.Context;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.UofWork;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IUnitOfWork context;
        public AutorController(IUnitOfWork context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            var aux = context.autores.GetAutoresYLibros();
            return Ok(aux);
        }
        [HttpPost]
        public ActionResult Post([FromBody] Autor autor)
        {
            context.autores.Insert(autor);
            context.Save();
            return new CreatedAtRouteResult("Autor", new { id = autor.Id }, autor);
        }
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Autor autor, int id)
        {
            if (id != autor.Id)
            {
                return BadRequest();
            }
            context.autores.Update(autor);
            context.Save();
            return Ok();

        }
        [HttpDelete("{numero}")]
        public ActionResult<Autor> Delete(int numero)
        {
            var autor = context.autores.GetById(numero);
            if (autor == null)
            {
                return NotFound();
            }
            context.autores.Delete(numero);
            context.Save();

            return autor;

        }
        [HttpGet("{id}")]
        public ActionResult<Autor> FindID(int id)
        {
            var autor = context.autores.GetAutorYLibros(id);
            if (autor == null)
            {
                return NotFound();
            }
            return autor;
        }
    }
}
