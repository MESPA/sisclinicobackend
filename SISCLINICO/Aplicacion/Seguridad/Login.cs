using MediatR;
using Microsoft.AspNetCore.Identity;
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
    public class Login
    {
        public class Ejecuta : IRequest<Usuario>
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string Token { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, Usuario>
        {

            private readonly UserManager<Usuario> _userManager;
            private readonly SignInManager<Usuario> _signInManager;
            private readonly IJwtGenerador _jwtGenerador;

            private readonly SisClinicoDbContext _context;
            public Manejador(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager
                , IJwtGenerador jwtGenerador, 
                SisClinicoDbContext context)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _jwtGenerador = jwtGenerador;
                _context = context;
            }
            public async Task<Usuario> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var usuario = await _userManager.FindByEmailAsync(request.Email);
                if (usuario == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.Unauthorized);
                }

                var resultado = await _signInManager.CheckPasswordSignInAsync(usuario, request.Password, false);
                //var resultadoRoles = await _userManager.GetRolesAsync(usuario);
                //var listaRoles = new List<string>(resultadoRoles);


                 
                //  var imagenPerfil = await _context.Documento.Where(x => x.ObjetoReferencia == new Guid(usuario.Id)).FirstOrDefaultAsync();

                if (resultado.Succeeded)
                {
                    //    if (imagenPerfil != null)
                    //    {
                    //        var imagenCliente = new ImagenGeneral
                    //        {
                    //            Data = Convert.ToBase64String(imagenPerfil.Contenido),
                    //            Extension = imagenPerfil.Extension,
                    //            Nombre = imagenPerfil.Nombre
                    //        };
                    //        return new UsuarioData
                    //        {
                    //            NombreCompleto = usuario.NombreCompleto,
                    //            Token = _jwtGenerador.CrearToken(usuario, listaRoles),
                    //            Username = usuario.UserName,
                    //            Email = usuario.Email,
                    //            ImagenPerfil = imagenCliente
                    //        };
                    //    }

                    {
                        return new Usuario
                        {
                            NombreCompleto = usuario.NombreCompleto,
                            Token = _jwtGenerador.CrearToken(usuario//, listaRoles
                             ),
                            UserName = usuario.UserName,
                            Email = usuario.Email,
                            //Imagen = null
                        };
                    }
                } 
                throw new ManejadorExcepcion(HttpStatusCode.Unauthorized);
            }



         




        }

    }
}
