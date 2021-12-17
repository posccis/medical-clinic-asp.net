using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using medical_clinic_rest_api;

#nullable disable

namespace medical_clinic_rest_api.Models
{
    public partial class clinica_medicaContext : DbContext
    {
        public clinica_medicaContext()
        {
        }

        public clinica_medicaContext(DbContextOptions<clinica_medicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agendaconsultum> Agendaconsulta { get; set; }
        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Clinicamedico> Clinicamedicos { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=clinica_medica;user=root;password=JK64victorjk", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Agendaconsultum>(entity =>
            {
                entity.HasKey(e => new { e.CodCli, e.CodMed, e.CpfPaciente, e.DataHora })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

                entity.Property(e => e.CpfPaciente).IsFixedLength(true);

                entity.HasOne(d => d.CpfPacienteNavigation)
                    .WithMany(p => p.Agendaconsulta)
                    .HasForeignKey(d => d.CpfPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("agendaconsulta_ibfk_2");

                entity.HasOne(d => d.Cod)
                    .WithMany(p => p.Agendaconsulta)
                    .HasForeignKey(d => new { d.CodCli, d.CodMed })
                    .HasConstraintName("agendaconsulta_ibfk_1");
            });

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.CodCli)
                    .HasName("PRIMARY");

                entity.Property(e => e.CodCli).ValueGeneratedNever();

                entity.Property(e => e.Telefone).IsFixedLength(true);
            });

            modelBuilder.Entity<Clinicamedico>(entity =>
            {
                entity.HasKey(e => new { e.CodCli, e.CodMed })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.Property(e => e.CargaHorariaSemanal).HasDefaultValueSql("'20.00'");

                entity.HasOne(d => d.CodCliNavigation)
                    .WithMany(p => p.Clinicamedicos)
                    .HasForeignKey(d => d.CodCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clinicamedico_ibfk_1");

                entity.HasOne(d => d.CodMedNavigation)
                    .WithMany(p => p.Clinicamedicos)
                    .HasForeignKey(d => d.CodMed)
                    .HasConstraintName("clinicamedico_ibfk_2");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.CodEspec)
                    .HasName("PRIMARY");

                entity.Property(e => e.CodEspec).ValueGeneratedNever();
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.CodMed)
                    .HasName("PRIMARY");

                entity.Property(e => e.CodMed).ValueGeneratedNever();

                entity.Property(e => e.Telefone).IsFixedLength(true);

                entity.HasOne(d => d.CodEspecNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.CodEspec)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("medico_ibfk_1");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.CpfPaciente)
                    .HasName("PRIMARY");

                entity.Property(e => e.CpfPaciente).IsFixedLength(true);

                entity.Property(e => e.Telefone).IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
