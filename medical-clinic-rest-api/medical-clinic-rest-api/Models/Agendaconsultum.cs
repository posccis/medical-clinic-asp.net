using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace medical_clinic_rest_api
{
    [Table("agendaconsulta")]
    [Index(nameof(CpfPaciente), Name = "CpfPaciente")]
    public partial class Agendaconsultum
    {
        [Key]
        public int CodCli { get; set; }
        [Key]
        public int CodMed { get; set; }
        [Key]
        [StringLength(11)]
        public string CpfPaciente { get; set; }
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime DataHora { get; set; }

        [ForeignKey("CodCli,CodMed")]
        [InverseProperty(nameof(Clinicamedico.Agendaconsulta))]
        public virtual Clinicamedico Cod { get; set; }
        [ForeignKey(nameof(CpfPaciente))]
        [InverseProperty(nameof(Paciente.Agendaconsulta))]
        public virtual Paciente CpfPacienteNavigation { get; set; }
    }
}
