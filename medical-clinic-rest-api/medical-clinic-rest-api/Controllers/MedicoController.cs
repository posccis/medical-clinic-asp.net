using medical_clinic_rest_api.Data;
using medical_clinic_rest_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
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
        private ClinicaMedicaDbContext _dbContext;

        public MedicoController(ClinicaMedicaDbContext dbContext)
        {

            _dbContext = dbContext;
            
        }

        [HttpGet]
        public async Task<IActionResult> MyProperty (Doctor doctor)
        {

            var connection = _dbContext.GetConnection();
            await connection.OpenAsync();

            List<Doctor> lista = new List<Doctor>();
            

            var query = new MySqlCommand("SELECT * FROM Medico", connection);

            var reader = await query.ExecuteReaderAsync();

            var value = reader.GetValue(0);
            

            return Ok(value);



        }
    }
}
