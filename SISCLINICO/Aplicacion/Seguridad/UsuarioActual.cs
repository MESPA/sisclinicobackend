using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using SisClinico.Context;
using SisClinico.Model;
using SISCLINICO.Aplicacion;
using SISCLINICO.Contratos;

namespace SISCLINICO.Aplicacion
{
    public class UsuarioActual
    {
        public class Ejecutar : IRequest<Usuario> { }

        public class Manejador : IRequestHandler<Ejecutar, Usuario>
        {
            private readonly UserManager<Usuario> _userManager;
            private readonly IJwtGenerador _jwtGenerador;
            private readonly IUsuarioSesion _usuarioSesion;
            private readonly SisClinicoDbContext _context;
            
            public Manejador(UserManager<Usuario> userManager, IJwtGenerador jwtGenerador, IUsuarioSesion usuarioSesion, SisClinicoDbContext context)
            {
                _userManager = userManager;
                _jwtGenerador = jwtGenerador;
                _usuarioSesion = usuarioSesion;
                _context = context;
            }
            public async Task<Usuario> Handle(Ejecutar request, CancellationToken cancellationToken)
            {
                var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

                //var resultadoRoles = await _userManager.GetRolesAsync(usuario);
                //var listaRoles = new List<string>(resultadoRoles);

                //var imagenPerfil = await _context.Documento.Where(x => x.ObjetoReferencia == new System.Guid(usuario.Id)).FirstOrDefaultAsync();
                //if (imagenPerfil != null)
                //{
                //    var imagenCliente = new ImagenGeneral
                //    {
                //        Data = Convert.ToBase64String(imagenPerfil.Contenido),
                //        Extension = imagenPerfil.Extension,
                //        Nombre = imagenPerfil.Nombre
                //    };

                //    return new UsuarioData
                //    {
                //        NombreCompleto = usuario.NombreCompleto,
                //        Username = usuario.UserName,
                //        Token = _jwtGenerador.CrearToken(usuario, listaRoles),
                //        Email = usuario.Email,
                //        ImagenPerfil = imagenCliente
                //    };
                //}
                //else
                {
                    return new Usuario
                    {
                        NombreCompleto = usuario.NombreCompleto,
                        UserName = usuario.UserName,
                        Token = _jwtGenerador.CrearToken(usuario//, listaRoles
                        ),
                        Email = usuario.Email
                    };
                }
            }

            
        }
    }
}





