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
    public class PacienteController : ControllerBase
    {
        clinica_medicaContext _dbContext;

        public PacienteController(clinica_medicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetPacientes()
        {
            var pacientes = await (from paciente in _dbContext.Pacientes
                                   select new
                                   {

                                       CpfPaciente = paciente.CpfPaciente,
                                       NomePac = paciente.NomePac,
                                       DataNascimento = paciente.DataNascimento,
                                       Genero = paciente.Genero,
                                       Telefone = paciente.Telefone,
                                       Email = paciente.Email
                                   }
                                   ).ToListAsync();
            return Ok(pacientes);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(string codigo)
        {
            var paciente = await _dbContext.Pacientes.Where(a => a.CpfPaciente == codigo).ToListAsync();

            return Ok(paciente[0]);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePaciente([FromBody] string codigo, string column, string valor)
        {
            var paciente = await _dbContext.Pacientes.Where(a => a.CpfPaciente == codigo).ToListAsync();

            if (column == "NomePac")
            {
                paciente[0].NomePac = valor;
            }
            else if (column == "DataNascimento")
            {
                paciente[0].DataNascimento = DateTime.Parse(valor);
            }
            else if (column == "Genero")
            {
                paciente[0].Genero = valor;
            }
            else if (column == "Telefone")
            {
                paciente[0].Telefone = valor;
            }
            else if (column == "Email")
            {
                paciente[0].Email = valor;
            }
            else
            {
                return BadRequest("You're probably trying to edit a field wich you should'nt");
            }

            _dbContext.Pacientes.Update(paciente[0]);

            await _dbContext.SaveChangesAsync();

            return Ok("Updated.");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaciente([FromBody] Paciente paciente) 
        {
            await _dbContext.Pacientes.AddAsync(paciente);

            await _dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]

        public async Task<IActionResult> DeletePaciente(string codigo)
        {
            var paciente = await _dbContext.Pacientes.Where(a => a.CpfPaciente == codigo).ToListAsync();

            _dbContext.Pacientes.Remove(paciente[0]);

            await _dbContext.SaveChangesAsync();

            return Ok("Deleted");
        }

    }
}
