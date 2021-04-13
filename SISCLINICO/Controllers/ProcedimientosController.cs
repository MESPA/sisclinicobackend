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
    public class ProcedimientosController : ControllerBase
    {

         private readonly SisClinicoDbContext context;

        public ProcedimientosController(SisClinicoDbContext context) {

            this.context = context;
             
    }
         #region procedimientos

          [HttpGet]
   
        public  ActionResult GetProcedimientos()
        {
            try
            {

                return Ok(context.Procedimientos.OrderByDescending(x => x.IdProcedimiento).Take(250).ToList()); 

                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("{id}", Name ="GetProcedimientos")]
    
        public ActionResult GetProcedimientos(int id)
        {
            try
            {
                var registros = context.Procedimientos.FirstOrDefault(r => r.IdProcedimiento == id);
                return Ok(registros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult PostProcedimientos([FromBody] Procedimientos procedimientos)
        {
            try
            {
               
                context.Procedimientos.Add(procedimientos);
                context.SaveChanges();
                return CreatedAtRoute("GetProcedimientos", new { id = procedimientos.IdProcedimiento }, procedimientos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcedimientos(int id, [FromBody] Procedimientos procedimientos)
        {
            try
            {
                if (id != procedimientos.IdProcedimiento)
                {
                    return BadRequest();
                }

                context.Update(procedimientos);
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