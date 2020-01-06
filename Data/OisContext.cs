using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data
{
    public partial class OisContext : DbContext
    {
        public OisContext()
        {
        }

        public OisContext(DbContextOptions<OisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Gradetype> Gradetype { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Studentinsubject> Studentinsubject { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Teacherofsubject> Teacherofsubject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5435;Database=ois;Username=silver;Password=a");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("grade");

                entity.Property(e => e.GradeId)
                    .HasColumnName("grade_id")
                    .HasDefaultValueSql("nextval('sq_grade'::regclass)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("character varying");

                entity.Property(e => e.GradetypeId).HasColumnName("gradetype_id");

                entity.Property(e => e.StudentinsubjectId).HasColumnName("studentinsubject_id");

                entity.Property(e => e.Timegiven).HasColumnName("timegiven");

                entity.HasOne(d => d.Studentinsubject)
                    .WithMany(p => p.GradeNavigation)
                    .HasForeignKey(d => d.StudentinsubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("grade_fk");
            });

            modelBuilder.Entity<Gradetype>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("gradetype_pk");

                entity.ToTable("gradetype");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.StudentId)
                    .HasColumnName("student_id")
                    .HasDefaultValueSql("nextval('sq_student'::regclass)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("character varying");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnName("dateofbirth")
                    .HasColumnType("date");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasColumnType("character varying");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasColumnType("character varying");

                entity.Property(e => e.Personalcode)
                    .HasColumnName("personalcode")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Studentinsubject>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("studentinsubject_pk");

                entity.ToTable("studentinsubject");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .HasDefaultValueSql("nextval('sq_studentinsubject'::regclass)");

                entity.Property(e => e.Autumnsemester).HasColumnName("autumnsemester");

                entity.Property(e => e.Confirmed).HasColumnName("confirmed");

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.Property(e => e.Pass).HasColumnName("pass");

                entity.Property(e => e.Semesteryear).HasColumnName("semesteryear");

                entity.Property(e => e.Springsemester).HasColumnName("springsemester");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.Timeregistered).HasColumnName("timeregistered");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("subject");

                entity.Property(e => e.SubjectId)
                    .HasColumnName("subject_id")
                    .HasDefaultValueSql("nextval('sq_subject'::regclass)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("character varying");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("character varying");

                entity.Property(e => e.Ects)
                    .HasColumnName("ects")
                    .HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teacher");

                entity.Property(e => e.TeacherId)
                    .HasColumnName("teacher_id")
                    .HasDefaultValueSql("nextval('sq_teacher'::regclass)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("character varying");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasColumnType("character varying");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Teacherofsubject>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("teacherofsubject_pk");

                entity.ToTable("teacherofsubject");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .HasDefaultValueSql("nextval('sq_teacherofsubject'::regclass)");

                entity.Property(e => e.Sincesemester)
                    .IsRequired()
                    .HasColumnName("sincesemester")
                    .HasColumnType("character varying");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            });

            modelBuilder.HasSequence("sq_grade");

            modelBuilder.HasSequence("sq_student");

            modelBuilder.HasSequence("sq_studentinsubject");

            modelBuilder.HasSequence("sq_subject");

            modelBuilder.HasSequence("sq_teacher");

            modelBuilder.HasSequence("sq_teacherofsubject");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
