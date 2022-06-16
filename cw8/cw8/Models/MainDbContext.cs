using Microsoft.EntityFrameworkCore;
using System;

namespace cw8.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }
        public MainDbContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }  
        public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }         
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer()
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Patient>(p =>
            {
                p.HasKey(e => e.IdPatient);
                p.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                p.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                p.Property(e => e.BirthDate).IsRequired();

                p.HasData(
                    new Patient { IdPatient = 1, FirstName = "Tomasz", LastName = "Blok", BirthDate = DateTime.Parse("2001-11-21") },
                    new Patient { IdPatient = 2, FirstName = "Mateusz", LastName = "Kowalski", BirthDate = DateTime.Parse("2001-10-15") },
                    new Patient { IdPatient = 3, FirstName = "Kamil", LastName = "Kowalski", BirthDate = DateTime.Parse("2001-10-10") }
                );
            });
            modelBuilder.Entity<Doctor>(d =>
            {
                d.HasKey(e => e.IdDoctor);
                d.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                d.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                d.Property(e => e.Email).IsRequired().HasMaxLength(100);

                d.HasData(
                    new Doctor { IdDoctor = 1, FirstName = "Andrzej", LastName = "Nowak", Email = "anowak@gmail.com" },
                    new Doctor { IdDoctor = 2, FirstName = "Krzysztof", LastName = "Jaki", Email = "kjaki@gmail.com" }
                );
            });
            modelBuilder.Entity<Prescription>(p =>
            {
                p.HasKey(e => e.IdPrescription);
                p.Property(e => e.Date).IsRequired();
                p.Property(e => e.DueDate).IsRequired();

                p.HasOne(e => e.Patient).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdPatient);
                p.HasOne(e => e.Doctor).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdDoctor);

                p.HasData(
                    new Prescription { IdPrescription = 1, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(32), IdPatient = 1, IdDoctor = 1},
                    new Prescription { IdPrescription = 2, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(72), IdPatient = 2, IdDoctor = 2 }
                );


            });
            modelBuilder.Entity<Medicament>(m =>
            {
                m.HasKey(e => e.IdMedicament);
                m.Property(e => e.Name).IsRequired().HasMaxLength(100);
                m.Property(e => e.Description).IsRequired().HasMaxLength(100);
                m.Property(e => e.Type).IsRequired().HasMaxLength(100);

                m.HasData(
                    new Medicament { IdMedicament = 1, Name = "Apap", Description = "Paracetamol 100mg", Type = "na ból zęba"},
                    new Medicament { IdMedicament = 2, Name = "Apap Extra", Description = "Paracetamol 200mg", Type = "na ból głowy"}
                    );
            });
            modelBuilder.Entity<PrescriptionMedicament>(p =>
            {
                p.HasKey(e => new
                {
                    e.IdMedicament,
                    e.IdPrescription
                });
                p.Property(e => e.Dose).IsRequired();
                p.Property(e => e.Details).IsRequired().HasMaxLength(100);

                p.HasOne(e => e.Medicament).WithMany(e => e.PrescriptionMedicaments).HasForeignKey(e => e.IdMedicament);
                p.HasOne(e => e.Prescription).WithMany(e => e.PrescriptionMedicaments).HasForeignKey(e => e.IdPrescription);

                p.HasData(
                    new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 1, Dose = 100, Details = "brać 1 tabletke rano i wieczorem"},
                    new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 2, Dose = 200, Details = "brać 1 tabletke rano i wieczorem" }
                    );
            });
            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(e => e.IdUser);
                u.Property(e => e.IdUser).UseIdentityColumn();
                u.Property(e => e.Login).IsRequired();
                u.HasIndex(e => e.Login).IsUnique();
                u.Property(e => e.Password).IsRequired();
                u.Property(e => e.Salt).IsRequired();
                u.Property(e => e.RefreshToken).IsRequired();
                u.Property(e => e.RefreshTokenExpireDate).IsRequired();

            });
        }
    }
}
