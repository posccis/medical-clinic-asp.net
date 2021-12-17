using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace medical_clinic_rest_api.Models
{
    public class Doctor
    {
        [Required(ErrorMessage = "All doctors need a code! ####\nCodMed can't be empty!")]
        public int CodMed { get; set; }

        [Required(ErrorMessage = "All doctors have a name! ####\nNomeMed can't be empty!")]
        public string NomeMed { get; set; }

        public string Genero { get; set; }

        public string Telefone { get; set; }
        public string Email { get; set; }

        public int CodEspec { get; set; }
    }
}
