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
    public class ClinicaMedicoController : ControllerBase
    {
        clinica_medicaContext _dbContext;

        public ClinicaMedicoController(clinica_medicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var clinicasmedicos = await (
                from clinica in _dbContext.Clinicamedicos
                select new
                {
                    CodCli = clinica.CodCli,
                    CodMed = clinica.CodMed,
                    DataIngresso = clinica.DataIngresso,
                    CargaHorariaSemanal = clinica.CargaHorariaSemanal
                }
                ).ToListAsync();
            return Ok(clinicasmedicos);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByCodMed(int codigo) 
        {
            var clinica = await _dbContext.Clinicamedicos.Where(a => a.CodMed == codigo).ToListAsync();

            return Ok(clinica);
        }

        [HttpGet("[action]")]
        public async  Task<IActionResult> GetByCodCli( int codigo) 
        {
            var clinica = await _dbContext.Clinicamedicos.Where(a => a.CodCli == codigo).ToListAsync();

            return Ok(clinica);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Clinicamedico clinicamedico) 
        {
            await _dbContext.Clinicamedicos.AddAsync(clinicamedico);
            await _dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int codigo, string column, string valor) 
        {
            var clinica = await _dbContext.Clinicamedicos.Where(a => a.CodCli == codigo || a.CodMed == codigo).ToListAsync();

            column = column.ToLower();

            if (column == "cargahorariasemanal")
            {
                clinica[0].CargaHorariaSemanal = float.Parse(valor);
            }
            else if (column == "dataingresso")
            {
                clinica[0].DataIngresso = DateTime.Parse(valor);
            }
            else
            {
                return BadRequest("Probably you're trying to edit a field wich you should'nt. Try antoher.");
            }

            _dbContext.Clinicamedicos.Update(clinica[0]);
            await _dbContext.SaveChangesAsync();

            return Ok("Updated.");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int codigo) 
        {
            var clinica = await _dbContext.Clinicamedicos.Where(a => a.CodCli == codigo || a.CodMed == codigo).ToListAsync();

            _dbContext.Clinicamedicos.Remove(clinica[0]);

            await _dbContext.SaveChangesAsync();

            return Ok("Deleted.");
        }

    }
}
