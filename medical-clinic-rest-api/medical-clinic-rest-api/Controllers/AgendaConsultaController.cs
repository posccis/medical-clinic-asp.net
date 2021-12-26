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
    public class AgendaConsultaController : ControllerBase
    {
        clinica_medicaContext _dbContext;

        public AgendaConsultaController(clinica_medicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var consultas = await (
                from consulta in _dbContext.Agendaconsulta
                select new
                {
                    CodCli = consulta.CodCli,
                    CodMed = consulta.CpfPaciente ,
                    CpfPaciente = consulta.CpfPaciente,
                    DataHora = consulta.DataHora
                }
                ).ToListAsync();

            return Ok(consultas);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByCpf (string cpf)
        {
            var consulta = await _dbContext.Agendaconsulta.Where(a => a.CpfPaciente == cpf).ToListAsync();

            return Ok(consulta);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Agendaconsultum agendaconsultum)
        {

            await _dbContext.Agendaconsulta.AddAsync(agendaconsultum);

            await _dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string cpf) 
        {
            var consulta = await _dbContext.Agendaconsulta.Where(a => a.CpfPaciente == cpf).ToListAsync();

            _dbContext.Agendaconsulta.Remove(consulta[0]);

            await _dbContext.SaveChangesAsync();

            return Ok("Deleted.");

        }
    }
}
