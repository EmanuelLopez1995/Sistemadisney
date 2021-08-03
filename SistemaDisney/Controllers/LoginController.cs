using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SimpleLogin.Helper;
using SistemaDisney.Data;
using SistemaDisney.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDisney.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly DisneyDbContext _context;
        private readonly IConfiguration config;
        public LoginController(DisneyDbContext context, IConfiguration _config)
        {
            _context = context;
            config = _config;
        }

        [HttpPost]

        public async Task<IActionResult> Post(LoginVM Login)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(400);
            }
            Usuario usuario = await _context.Usuarios.Where(x => x.User == Login.Usuario).FirstOrDefaultAsync();
            if(usuario == null)
            {
                return NotFound(404);
            }

            if(HashHelper.CheckHash(Login.Clave,usuario.Password,usuario.Sal))
            {
                var secretKey = config.GetValue<string>("SecretKey");
                var key = Encoding.ASCII.GetBytes(secretKey);

                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, Login.Usuario));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddHours(4),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                string bearer_token = tokenHandler.WriteToken(createdToken);
                return Ok(bearer_token);
            }
            else
            {
                return Forbid();
            }
        }
    }
}
