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
    public class DiagnosticosController:ControllerBase
    {
        #region Diagnostico

        private readonly SisClinicoDbContext context;

        public DiagnosticosController(SisClinicoDbContext context) {

            this.context = context;
             
    }
         

          [HttpGet]
   
        public  ActionResult GetDiagostico()
        {
            try
            {

                return Ok(context.Diagnostico.OrderByDescending(x => x.IdDiagnostico).Take(250).ToList()); 

                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("{id}", Name ="GetDiagnostico")]
    
        public ActionResult GetDiagnostico(int id)
        {
            try
            {
                var registros = context.Diagnostico.FirstOrDefault(r => r.IdDiagnostico == id);
                return Ok(registros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult PostDiagnostico([FromBody] Diagnostico diagnostico)
        {
            try
            {
               
                context.Diagnostico.Add(diagnostico);
                context.SaveChanges();
                return CreatedAtRoute("GetDiagnostico", new { id = diagnostico.IdDiagnostico }, diagnostico);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiagnostico(int id, [FromBody] Diagnostico diagnostico)
        {
            try
            {
                if (id != diagnostico.IdDiagnostico)
                {
                    return BadRequest();
                }

                context.Update(diagnostico);
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