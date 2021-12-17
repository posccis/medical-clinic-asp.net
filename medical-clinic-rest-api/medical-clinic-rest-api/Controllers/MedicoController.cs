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


    }
}
