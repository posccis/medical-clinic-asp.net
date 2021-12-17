using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medical_clinic_rest_api.Data
{
    public class ClinicaMedicaDbContext
    {
        public string ConnectionString { get; set; }

        public ClinicaMedicaDbContext(string connectionString) 
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
