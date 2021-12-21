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
    public class EspecialidadeController : ControllerBase
    {
        private clinica_medicaContext _dbContext;

        public EspecialidadeController(clinica_medicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetEspecialidades() 
        {
            var especialidades = await (from especialidade in _dbContext.Especialidades
                                       select new
                                       {
                                           CodEspec = especialidade.CodEspec,
                                           NomeEspec = especialidade.NomeEspec,
                                           Descricao = especialidade.Descricao
                                       }
                                       ).ToListAsync();
            return Ok(especialidades);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByCod(int codigo) 
        {
            var especialidade = await _dbContext.Especialidades.Where(a => a.CodEspec == codigo).ToListAsync();
            
            return Ok(especialidade);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEspecialidade([FromBody] Especialidade especialidade) 
        {
            await _dbContext.AddAsync(especialidade);
            await _dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEspecialidade(int codigo, string column, string valor) 
        {
            var especialidade = await _dbContext.Especialidades.Where(a => a.CodEspec == codigo).ToListAsync();

            column = column.ToLower();

            if (column == "nomeespec")
            {
                especialidade[0].NomeEspec = valor;
            }
            else if (column == "descricao")
            {
                especialidade[0].Descricao = valor;
            }
            else
            {
                return BadRequest("Probabily you're trying to edit a field wich you should'nt");
            }

            _dbContext.Especialidades.Update(especialidade[0]);
            await _dbContext.SaveChangesAsync();

            return Ok("Updated.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEspecialidade(int codigo) 
        {
            var especialidade = await _dbContext.Especialidades.Where(a => a.CodEspec == codigo).ToListAsync();
            _dbContext.Especialidades.Remove(especialidade[0]);
            await _dbContext.SaveChangesAsync();

            return Ok("Specialty deleted.");
            
        }
    }
}
