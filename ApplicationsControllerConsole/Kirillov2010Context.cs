using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ApplicationsControllerConsole;

public partial class Kirillov2010Context : DbContext
{
    public Kirillov2010Context()
    {
    }

    public Kirillov2010Context(DbContextOptions<Kirillov2010Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationType> ApplicationTypes { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<GroupApplicationContact> GroupApplicationContacts { get; set; }

    public virtual DbSet<PersonalVisitor> PersonalVisitors { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("userid=student;password=student;database=kirillov2010;server=192.168.200.13", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.39-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Application");

            entity.HasIndex(e => e.DepartmentId, "Application_Department_FK");

            entity.HasIndex(e => e.EmployeeId, "Application_Employee_FK");

            entity.HasIndex(e => e.ApplicationTypeId, "Application_application_type_FK");

            entity.HasIndex(e => e.StatusId, "Application_status_FK");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ApplicantEmail)
                .HasMaxLength(100)
                .HasColumnName("applicant_email");
            entity.Property(e => e.ApplicationTypeId)
                .HasColumnType("int(11)")
                .HasColumnName("application_type_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DepartmentId)
                .HasColumnType("int(11)")
                .HasColumnName("department_id");
            entity.Property(e => e.EmployeeId)
                .HasColumnType("int(11)")
                .HasColumnName("employee_id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.Purpose)
                .HasMaxLength(100)
                .HasColumnName("purpose");
            entity.Property(e => e.RejectionReason)
                .HasMaxLength(100)
                .HasColumnName("rejection_reason");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.StatusId)
                .HasColumnType("int(11)")
                .HasColumnName("status_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.ApplicationType).WithMany(p => p.Applications)
                .HasForeignKey(d => d.ApplicationTypeId)
                .HasConstraintName("Application_application_type_FK");

            entity.HasOne(d => d.Department).WithMany(p => p.Applications)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("Application_Department_FK");

            entity.HasOne(d => d.Employee).WithMany(p => p.Applications)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("Application_Employee_FK");

            entity.HasOne(d => d.Status).WithMany(p => p.Applications)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("Application_status_FK");
        });

        modelBuilder.Entity<ApplicationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("application_type");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Department");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Employee");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DepartamentId)
                .HasColumnType("int(11)")
                .HasColumnName("departament_id");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
        });

        modelBuilder.Entity<GroupApplicationContact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("GroupApplicationContact");

            entity.HasIndex(e => e.ApplicationId, "GroupApplicationContact_Application_FK");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ApplicationId)
                .HasColumnType("int(11)")
                .HasColumnName("application_id");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(100)
                .HasColumnName("contact_email");
            entity.Property(e => e.ContactName)
                .HasMaxLength(100)
                .HasColumnName("contact_name");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(100)
                .HasColumnName("contact_phone");
            entity.Property(e => e.Organization)
                .HasMaxLength(100)
                .HasColumnName("organization");

            entity.HasOne(d => d.Application).WithMany(p => p.GroupApplicationContacts)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("GroupApplicationContact_Application_FK");
        });

        modelBuilder.Entity<PersonalVisitor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("PersonalVisitor");

            entity.HasIndex(e => e.ApplicationId, "PersonalVisitor_Application_FK");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ApplicationId)
                .HasColumnType("int(11)")
                .HasColumnName("application_id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Organization)
                .HasMaxLength(100)
                .HasColumnName("organization");
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(100)
                .HasColumnName("passport_number");
            entity.Property(e => e.PassportSeries)
                .HasMaxLength(100)
                .HasColumnName("passport_series");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .HasColumnName("phone");

            entity.HasOne(d => d.Application).WithMany(p => p.PersonalVisitors)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("PersonalVisitor_Application_FK");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("status");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
