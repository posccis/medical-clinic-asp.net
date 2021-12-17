using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace medical_clinic_rest_api
{
    [Table("especialidade")]
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        [Key]
        public int CodEspec { get; set; }
        [StringLength(30)]
        public string NomeEspec { get; set; }
        [Required]
        [StringLength(40)]
        public string Descricao { get; set; }

        [InverseProperty(nameof(Medico.CodEspecNavigation))]
        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
