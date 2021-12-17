using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace medical_clinic_rest_api.Models
{
    public class MarcarConsulta
    {
        [Required(ErrorMessage = "Every query appointment need a clinic code!####CodCli can't be empty!")]
        public int CodCli { get; set; }

        [Required(ErrorMessage = "Every query appointment need a doctor code!####CodMed can't be empty!")]
        public string CodMed { get; set; }

        [Required(ErrorMessage = "Every query appointment have a patient!####CpfPaciente can't be empty!")]
        public string CpfPaciente { get; set; }

        [Required(ErrorMessage = "Every appointment have a Date and hour!####DataHora can't be empty!")]
        public string DataHora { get; set; }
    }
}
