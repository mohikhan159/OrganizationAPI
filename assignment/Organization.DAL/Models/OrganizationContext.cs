using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Organization.DAL.Models
{
    public partial class OrganizationContext : DbContext, IOrganizationContext
    {
        public OrganizationContext()
        {
        }

        public OrganizationContext(DbContextOptions<OrganizationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contractor> Contractors { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<Supervisor> Supervisors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=.\\SQLExpress;Initial Catalog=Organization;Integrated Security=True");
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["OrganizationConnection"].ConnectionString);

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contractor>(entity =>
            {
                entity.Property(e => e.ContractorId)
                    .ValueGeneratedNever()
                    .HasColumnName("ContractorID");

                entity.Property(e => e.PayPerHour).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.ContractorNavigation)
                    .WithOne(p => p.Contractor)
                    .HasForeignKey<Contractor>(d => d.ContractorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contracto__Contr__440B1D61");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Address1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.Property(e => e.ManagerId)
                    .ValueGeneratedNever()
                    .HasColumnName("ManagerID");

                entity.Property(e => e.AnnualSalary).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MaxExpenseAmount).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.ManagerNavigation)
                    .WithOne(p => p.Manager)
                    .HasForeignKey<Manager>(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Managers__Manage__49C3F6B7");
            });

            modelBuilder.Entity<Supervisor>(entity =>
            {
                entity.Property(e => e.SupervisorId)
                    .ValueGeneratedNever()
                    .HasColumnName("SupervisorID");

                entity.Property(e => e.AnnualSalary).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.SupervisorNavigation)
                    .WithOne(p => p.Supervisor)
                    .HasForeignKey<Supervisor>(d => d.SupervisorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Superviso__Super__46E78A0C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
