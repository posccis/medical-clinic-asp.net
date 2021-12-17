using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace medical_clinic_rest_api
{
    [Table("clinicamedico")]
    [Index(nameof(CodMed), Name = "CodMed")]
    public partial class Clinicamedico
    {
        public Clinicamedico()
        {
            Agendaconsulta = new HashSet<Agendaconsultum>();
        }

        [Key]
        public int CodCli { get; set; }
        [Key]
        public int CodMed { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataIngresso { get; set; }
        [Column(TypeName = "float(4,2)")]
        public float? CargaHorariaSemanal { get; set; }

        [ForeignKey(nameof(CodCli))]
        [InverseProperty(nameof(Clinica.Clinicamedicos))]
        public virtual Clinica CodCliNavigation { get; set; }
        [ForeignKey(nameof(CodMed))]
        [InverseProperty(nameof(Medico.Clinicamedicos))]
        public virtual Medico CodMedNavigation { get; set; }
        [InverseProperty(nameof(Agendaconsultum.Cod))]
        public virtual ICollection<Agendaconsultum> Agendaconsulta { get; set; }
    }
}
