using ApiBiblio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBiblio.Controllers
{
    [ApiController]
    [Route("autor")]
    public class AutorController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public AutorController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await dbContext.Autores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            dbContext.Add(autor);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if (autor.Id != id)
            {
                return BadRequest("El id del autor no coincide con el establecido en la url.");
            }

            dbContext.Update(autor);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var atDelete = await dbContext.Autores.FindAsync(id);
            dbContext.Autores.Remove(atDelete);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
