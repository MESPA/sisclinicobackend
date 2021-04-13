
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisClinico.Model;
using SISCLINICO.Aplicacion;
using SISCLINICO.Aplicacion.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISCLINICO.Controllers
{
    [AllowAnonymous]

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
     
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator) {

            _mediator = mediator;
        }

        [HttpPost("login")]
    
        public async Task<ActionResult<Usuario>> Login(Login.Ejecuta parametros)
        {
            return await _mediator.Send(parametros);
        }
        //http://localhost:5000/
        [HttpPost("registrar")]
        public async Task<ActionResult<Usuario>> Registrar(Registrar.Ejecuta parametros)
        {
            return await _mediator.Send(parametros);
        }

        [HttpGet]
        public async Task<ActionResult<Usuario>> DevolverUsuario()
        {
            return await _mediator.Send(new UsuarioActual.Ejecutar());
        }

 

      
        [HttpPut]
        public async Task<ActionResult<Usuario>> Actualizar(UsuarioActualizar.Ejecuta parametros)
        {
            return await _mediator.Send(parametros);
        }

    }
}


