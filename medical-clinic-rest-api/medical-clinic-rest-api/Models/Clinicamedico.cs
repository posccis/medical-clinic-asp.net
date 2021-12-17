using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace medical_clinic_rest_api.Models
{
    public class Clinicamedico
    {
        [Required(ErrorMessage = "Every clinic have a code!####CodCli can't be empty!")]
        public int CodCli { get; set; }

        [Required(ErrorMessage = "Every doctor in the clinic have a code!####CodMed can't be empty!")]
        public int CodMed { get; set; }


        public string DataIngresso { get; set; }

        public float CargaHorariaSemanal { get; set; }



    }
}
