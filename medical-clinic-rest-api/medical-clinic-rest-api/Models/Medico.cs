using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace medical_clinic_rest_api
{
    [Table("medico")]
    [Index(nameof(CodEspec), Name = "CodEspec")]
    [Index(nameof(Email), Name = "Email", IsUnique = true)]
    public partial class Medico
    {
        public Medico()
        {
            Clinicamedicos = new HashSet<Clinicamedico>();
        }

        [Key]
        public int CodMed { get; set; }
        [StringLength(15)]
        public string NomeMed { get; set; }
        [StringLength(15)]
        public string Genero { get; set; }
        [StringLength(11)]
        public string Telefone { get; set; }
        [StringLength(40)]
        public string Email { get; set; }
        public int? CodEspec { get; set; }

        [ForeignKey(nameof(CodEspec))]
        [InverseProperty(nameof(Especialidade.Medicos))]
        public virtual Especialidade CodEspecNavigation { get; set; }
        [InverseProperty(nameof(Clinicamedico.CodMedNavigation))]
        public virtual ICollection<Clinicamedico> Clinicamedicos { get; set; }
    }
}
