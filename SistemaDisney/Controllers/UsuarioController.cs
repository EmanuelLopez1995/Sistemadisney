using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleLogin.Helper;
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
    public class UsuarioController : ControllerBase
    {
        private readonly DisneyDbContext _context;
        public UsuarioController(DisneyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Get()
        {
            List<UsuarioVM> Usuarios = await _context.Usuarios.Select(x => new UsuarioVM()
            {
                IdUsuario = x.IdUusario,
                User = x.User
            }).ToListAsync();
            return Ok(Usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            UsuarioVM Usuarios = await _context.Usuarios.Where(x => x.IdUusario == id).Select(x => new UsuarioVM()
            {
                IdUsuario = x.IdUusario,
                User = x.User
            }).SingleOrDefaultAsync();
            return Ok(Usuarios);
        }


        [HttpPost]

        public async Task<IActionResult> Post(Usuario usuario)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(400);
            }
            if(await _context.Usuarios.Where(x=>x.User == usuario.User).AnyAsync())
            {
                return BadRequest(400);
            }

            HashedPassword Password = HashHelper.Hash(usuario.Password);
            usuario.Password = Password.Password;
            usuario.Sal = Password.Salt;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Ok(new UsuarioVM()
            {
                IdUsuario = usuario.IdUusario,
                User = usuario.User
            });

        }
    }
}
