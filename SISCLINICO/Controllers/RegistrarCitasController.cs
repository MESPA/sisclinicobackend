using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SisClinico.Context;
using SISCLINICO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISCLINICO.Controllers
{
         [ApiController]
         [Route("api/[controller]")]
    public class RegistrarCitasController : ControllerBase
    {

        private readonly SisClinicoDbContext context;

        public RegistrarCitasController(SisClinicoDbContext context) {

            this.context = context;
             
    }
        #region Citas

          [HttpGet]
   
        public  ActionResult GetCitas()
        {
            try
            {

                return Ok(context.Citas.OrderByDescending(x => x.IdCitas).Take(250).ToList()); 

                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }
     [HttpGet("{id}", Name ="GetCitas")]
    
        public ActionResult GetCitas(int id)
        {
            try
            {
                var registros = context.Citas.FirstOrDefault(r => r.IdCitas == id);
                return Ok(registros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult PostCitas([FromBody] Citas citas)
        {
            try
            {
               
                context.Citas.Add(citas);
                context.SaveChanges();
                return CreatedAtRoute("GetCitas", new { id = citas.IdCitas }, citas);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitas(int id, [FromBody] Citas citas)
        {
            try
            {
                if (id != citas.IdCitas)
                {
                    return BadRequest();
                }

                context.Update(citas);
                await context.SaveChangesAsync();
                return Ok(new { message = "actualizado con exito!" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        #endregion
       
    }
}