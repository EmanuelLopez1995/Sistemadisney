using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDisney.Data;
using SistemaDisney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDisney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PeliculaController : ControllerBase
    {
        private readonly DisneyDbContext _context;
        public PeliculaController(DisneyDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<Pelicula> Get()
        {
            return _context.Peliculas.ToList();
        }

        //create
        [HttpPost("{id}")]
        public ActionResult Post(Pelicula pelicula)
        {
            _context.Peliculas.Add(pelicula);
            _context.SaveChanges();

            //ver aca //return Ok();
            return new CreatedAtRouteResult("InsertarPersona", new { id = pelicula.PeliculaID }, pelicula);
        }

        //update

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pelicula pelicula)
        {
            if (id != pelicula.PeliculaID)
            {
                return BadRequest();
            }
            _context.Entry(pelicula).State = EntityState.Modified; 
            _context.SaveChanges();
            return Ok();
        }

        //delete

        [HttpDelete("{id}")]
        public ActionResult<Pelicula> Delete(int id)
        {
            var pelicula = _context.Peliculas.Find(id);

            if (pelicula == null)
            {
                return NotFound();
            }
            _context.Peliculas.Remove(pelicula);
            _context.SaveChanges();
            return pelicula;
        }

    }
}
