using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace medical_clinic_rest_api.Models
{
    public class Specialty
    {
        [Required(ErrorMessage ="All specialties need a code!####CodEspec can't be empty!")]
        public int CodEspec { get; set; }

        [Required(ErrorMessage="All specialties have a name!####\nNomeEspec can't be empty!")]
        public string NomeEspec { get; set; }

        public string Descricao { get; set; }
    }
}
