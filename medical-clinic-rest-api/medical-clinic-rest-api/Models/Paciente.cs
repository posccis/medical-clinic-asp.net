using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace medical_clinic_rest_api.Models
{
    public class Paciente
    {

        [Required(ErrorMessage = "Every pacient need a CPF!####Cpf can't be empty!")]
        public string CpfPaciente { get; set; }

        [Required(ErrorMessage = "Every pacient have a birth date!####DataNascimento can't be empty!")]
        public string DataNascimento { get; set; }

        public string Genero { get; set; }

        public string Telefone { get; set; }

        public EmailAddressAttribute Email { get; set; }
    }
}
