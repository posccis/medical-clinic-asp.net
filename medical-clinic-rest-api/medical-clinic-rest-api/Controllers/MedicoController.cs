using medical_clinic_rest_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medical_clinic_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private clinica_medicaContext _dbContext;

        public MedicoController(clinica_medicaContext dbContext)
        {
            _dbContext = dbContext;
        }
        ///List all the doctors
        [HttpGet]
        public async Task<IActionResult> GetAllMedicos() 
        {
            
            var medicos = await (
                from medico in _dbContext.Medicos
                select new
                {
                    CodMed = medico.CodMed,
                    NomeMed = medico.NomeMed,
                    Genero = medico.Genero,
                    Telefone = medico.Telefone,
                    Email = medico.Email,
                    CodEspec = medico.CodEspec
                }
                ).ToListAsync();

            return Ok(medicos);
        }
        ///Search for a doctor with the code
        [HttpGet("[action]")]
        public async Task<IActionResult> MedicoByCod(int Codigo) 
        {
            var medico = await _dbContext.Medicos.Where(a => a.CodMed == Codigo).ToListAsync();
            return Ok(medico);
        }

        ///Create a doctor
        [HttpPost]
        public async Task<IActionResult> MedicoCreate([FromBody] Medico medico)
        {
            await _dbContext.Medicos.AddAsync(medico);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        ///Update one especific column
        [HttpPut]
        public async Task<IActionResult> MedicoUpdate(int codigo, string column, string valor)
        {

            var medico_ = await _dbContext.Medicos.Where(a => a.CodMed == codigo).ToListAsync();

            column = column.ToLower();

            if (column == "nomemed")
            {
               medico_[0].NomeMed = valor;
            }
            else if (column == "genero")
            {
                medico_[0].Genero = valor;
            }
            else if (column == "telefone")
            {
                medico_[0].Telefone = valor;
            }
            else if (column == "email")
            {
                medico_[0].Email = valor;
            }
            else
            {
                return BadRequest("Probabily you're trying to edit a field wich you should'nt. Try other.");
            }

            _dbContext.Medicos.Update(medico_[0]);
            await _dbContext.SaveChangesAsync();

            return Ok(medico_);



        }

        [HttpDelete]
        public async Task<IActionResult> MedicoDel(int codigo) 
        {
            var medico_ = await _dbContext.Medicos.Where(a => a.CodMed == codigo).ToListAsync();

            _dbContext.Remove(medico_[0]);
            await _dbContext.SaveChangesAsync();

            return Ok("Item deleted.");
        }




    }
}
