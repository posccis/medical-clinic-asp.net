using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace medical_clinic_rest_api
{
    [Table("clinica")]
    public partial class Clinica
    {
        public Clinica()
        {
            Clinicamedicos = new HashSet<Clinicamedico>();
        }

        [Key]
        public int CodCli { get; set; }
        [StringLength(15)]
        public string NomeCli { get; set; }
        [StringLength(40)]
        public string Endereco { get; set; }
        [StringLength(11)]
        public string Telefone { get; set; }
        [StringLength(40)]
        public string Email { get; set; }

        [InverseProperty(nameof(Clinicamedico.CodCliNavigation))]
        public virtual ICollection<Clinicamedico> Clinicamedicos { get; set; }
    }
}
