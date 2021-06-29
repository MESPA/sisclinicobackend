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
    public class RegistrosDoctoresController : ControllerBase
    {
     

        private readonly SisClinicoDbContext context;

        public RegistrosDoctoresController(SisClinicoDbContext context) {

            this.context = context;
             
    }
        #region Doctores

        [HttpGet]
   
        public  ActionResult GetDoctores()
        {
            try
            {

                return Ok(context.Doctores.OrderByDescending(x => x.IdDoctores).Take(250).ToList()); 

                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("{id}", Name ="GetDoctores")]
    
        public ActionResult GetDoctores(int id)
        {
            try
            {
                var registros = context.Doctores.FirstOrDefault(r => r.IdDoctores == id);
                return Ok(registros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult PostDoctores([FromBody] Doctores doctores)
        {
            try
            {
               
                context.Doctores.Add(doctores);
                context.SaveChanges();
                return CreatedAtRoute("GetDoctores", new { id = doctores.IdDoctores }, doctores);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctores(int id, [FromBody] Doctores doctores)
        {
            try
            {
                if (id != doctores.IdDoctores)
                {
                    return BadRequest();
                }

                context.Update(doctores);
                await context.SaveChangesAsync();
                return Ok(new { message = " actualizado con exito!" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        #endregion
       
        }
        
    }