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
    public class ClinicaController : ControllerBase
    {
        clinica_medicaContext _dbContext;

        public ClinicaController(clinica_medicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClinics() 
        {
            var clinicas = await (
                from clinica in _dbContext.Clinicas
                select new
                {
                    CodCli = clinica.CodCli,
                    NomeCli = clinica.NomeCli,
                    Endereço = clinica.Endereco,
                    Telefone = clinica.Telefone,
                    Email = clinica.Email
                }
                                  ).ToListAsync();
            return Ok(clinicas);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(int codigo)
        {
            var clinica = await _dbContext.Clinicas.Where(a => a.CodCli == codigo).ToListAsync();

            return Ok(clinica[0]);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClinica([FromBody] Clinica clinica) 
        {
            await _dbContext.Clinicas.AddAsync(clinica);
            await _dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClinica(int codigo, string column, string valor) 
        {
            var clinica = await _dbContext.Clinicas.Where(a => a.CodCli == codigo).ToListAsync();

            if (column == "NomeCli")
            {
                clinica[0].NomeCli = valor;
            }
            else if (column == "Endereco")
            {
                clinica[0].Endereco = valor;
            }
            else if (column == "Telefone")
            {
                clinica[0].Telefone = valor;
            }
            else if (column == "Email")
            {
                clinica[0].Email = valor;
            }
            else
            {
                return BadRequest("You're probably trying to edit a field wich you should'nt.");
            }

            _dbContext.Clinicas.Update(clinica[0]);

            await _dbContext.SaveChangesAsync();

            return Ok("Updated.");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClinica(int codigo) 
        {
            var clinica = await _dbContext.Clinicas.Where(a => a.CodCli == codigo).ToListAsync();

            _dbContext.Clinicas.Remove(clinica[0]);
            await _dbContext.SaveChangesAsync();
            return Ok("Deleted");
        }
    }
}
