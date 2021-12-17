using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace medical_clinic_rest_api.Models
{
    public class Clinica
    {
        [Required(ErrorMessage = "All clinics need a code!####CodCli can't be empty!")]
        public int CodCli { get; set; }

        [Required(ErrorMessage = "All clinics need a Name!####NomeCli can't be empty!")]
        public string NomeCli { get; set; }

        [Required(ErrorMessage ="All clinics need a address!####Endereco can't be empty!")]
        public string Endereco { get; set; }


        public string Telefone { get; set; }

        
        public string Email { get; set; }
    }
}
