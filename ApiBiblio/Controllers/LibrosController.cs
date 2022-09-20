using ApiBiblio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace ApiBiblio.Controllers
{
    [ApiController]
    [Route("libros")]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public LibrosController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }

        [HttpGet]
        public async Task<ActionResult<List<Libro>>> Get()
        {
            return await dbContext.Libros.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Libro libros)
        {
            dbContext.Add(libros);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Libro libros, int id)
        {
            if (libros.Id != id)
            {
                return BadRequest("El id del libro no coincide con el establecido en la url.");
            }

            dbContext.Update(libros);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var libDelete = await dbContext.Libros.FindAsync(id);
            dbContext.Libros.Remove(libDelete);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
