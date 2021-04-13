using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SisClinico.Context;
using SisClinico.Model;
using SISCLINICO.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SISCLINICO.Aplicacion
{
    public class Registrar
    {
        public class Ejecuta : IRequest<Usuario>
        {
            public string NombreCompleto { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string UserName { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, Usuario>
        {
            private readonly SisClinicoDbContext _context;
            private readonly UserManager<Usuario> _userManager;
            private readonly IJwtGenerador _jwtGenerador;
            public Manejador(SisClinicoDbContext context, UserManager<Usuario> userManager, IJwtGenerador jwtGenerador
                )
            {
                _context = context;
                _userManager = userManager;
                _jwtGenerador = jwtGenerador;
            }

            public async Task<Usuario> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var existe = await _context.Users.Where(x => x.Email == request.Email).AnyAsync();
                if (existe)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "Existe ya un usuario registrado con este email" });
                }

                var existeUserName = await _context.Users.Where(x => x.UserName == request.UserName).AnyAsync();
                if (existeUserName)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "Existe ya un usuario con este username" });
                }


                var usuario = new Usuario
                {
                    NombreCompleto = request.NombreCompleto,
                    Email = request.Email,
                    UserName = request.UserName
                };

                var resultado = await _userManager.CreateAsync(usuario, request.Password);
                if (resultado.Succeeded)
                {
                    return new Usuario
                    {
                        NombreCompleto = usuario.NombreCompleto,
                       Token = _jwtGenerador.CrearToken(usuario
                             ),
                        UserName = usuario.UserName,
                        Email = usuario.Email
                    };
                }



                throw new Exception("No se pudo agregar al nuevo usuario");
            }
        }

    }
}
