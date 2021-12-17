using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace medical_clinic_rest_api
{
    [Table("paciente")]
    [Index(nameof(Email), Name = "Email", IsUnique = true)]
    public partial class Paciente
    {
        public Paciente()
        {
            Agendaconsulta = new HashSet<Agendaconsultum>();
        }

        [Key]
        [StringLength(11)]
        public string CpfPaciente { get; set; }
        [StringLength(15)]
        public string NomePac { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataNascimento { get; set; }
        [StringLength(15)]
        public string Genero { get; set; }
        [StringLength(11)]
        public string Telefone { get; set; }
        [StringLength(40)]
        public string Email { get; set; }

        [InverseProperty(nameof(Agendaconsultum.CpfPacienteNavigation))]
        public virtual ICollection<Agendaconsultum> Agendaconsulta { get; set; }
    }
}
