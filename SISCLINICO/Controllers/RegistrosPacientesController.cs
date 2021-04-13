using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SisClinico.Context;
using SisClinico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISCLINICO.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    

    public class RegistrosPacientesController : ControllerBase
    {
        private readonly SisClinicoDbContext context;

        public RegistrosPacientesController(SisClinicoDbContext context) {

            this.context = context;
             
    }
        #region paciente

        // GET: RegistrosController
        [HttpGet]
   
        public  ActionResult Get()
        {
            try
            {
                var consulta = (context.Paciente.OrderByDescending(x => x.IdPaciente).Take(250).ToList()); 

                return Ok(consulta);
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("{id}", Name ="GetPaciente")]
    
        public ActionResult Get(int id)
        {
            try
            {


                var registros = context.Paciente.FirstOrDefault(r => r.IdPaciente == id);
                return Ok(registros);


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // POST
        [HttpPost]
        public ActionResult Post([FromBody] Paciente paciente)
        {
            try
            {
               
                context.Paciente.Add(paciente);
                context.SaveChanges();
                return CreatedAtRoute("GetPaciente", new { id = paciente.IdPaciente }, paciente);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Paciente paciente)
        {
            try
            {
                if (id != paciente.IdPaciente)
                {
                    return BadRequest();
                }

                context.Update(paciente);
                await context.SaveChangesAsync();
                return Ok(new { message = "Comantario actualizado con exito!" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

      
       

        #endregion

    }
}
