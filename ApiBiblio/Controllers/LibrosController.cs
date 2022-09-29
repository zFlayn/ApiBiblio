using ApiBiblio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace ApiBiblio.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {        
        private readonly ApplicationDbContext dbContext;

        public LibrosController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }

        public ApplicationDbContext DbContext { get; }
        [HttpGet("primero")] //api/libros/primero
        public async Task<ActionResult<Libro>> PrimerLibro()
        {
            return await dbContext.Libros.FirstOrDefaultAsync();
        }

        [HttpGet]
        [HttpGet("listado")]
        [HttpGet("/listado")]
        public async Task<ActionResult<List<Libro>>> Get()
        {
            return await dbContext.Libros.Include(x => x.Datos).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> Get(int id)
        {
            var libro = await dbContext.Libros.FirstOrDefaultAsync(x => x.Id == id);  
            if(libro == null)
            {
                return NotFound();
            }

            return libro;
        }

        /*
        [HttpGet("[nombre]")]
        public async Task<ActionResult<Libro>> Get(string nombre)
        {
            var libro = await dbContext.Libros.FirstOrDefaultAsync(x => x.Name.Contains(nombre));

            if (libro == null)
            {
                return NotFound();
            } 

            return libro;
        }
        */

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
