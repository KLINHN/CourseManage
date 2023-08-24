using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessData.Models
{
    public partial class CourseManageContext : DbContext
    {
        public CourseManageContext()
        {
        }

        public CourseManageContext(DbContextOptions<CourseManageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Major> Majors { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Semester> Semesters { get; set; } = null!;
        public virtual DbSet<Session> Sessions { get; set; } = null!;
        public virtual DbSet<Slot> Slots { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("CourseManagement")).EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AbsentCount).HasColumnName("absent_count");

                entity.Property(e => e.StudentId).HasColumnName("student_id");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.Property(e => e.StudentInCourse).HasColumnName("student_in_course");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Room_Course");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("FK_Room_Session");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("Semester");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.MajorId).HasColumnName("major_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Semesters)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Semester_Subject");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("Session");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.SlotId).HasColumnName("slot_id");

                entity.HasOne(d => d.Slot)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.SlotId)
                    .HasConstraintName("FK_Session_Slot");
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                entity.ToTable("Slot");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.TimeEnd)
                    .HasMaxLength(50)
                    .HasColumnName("time_end");

                entity.Property(e => e.TimeStart)
                    .HasMaxLength(50)
                    .HasColumnName("time_start");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AttendanceId).HasColumnName("attendance_id");

                entity.Property(e => e.MajorId).HasColumnName("major_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.HasOne(d => d.Attendance)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.AttendanceId)
                    .HasConstraintName("FK_Student_Attendance");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("FK_Student_Major");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.MajorId).HasColumnName("major_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Subject_Course");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("FK_Subject_Major");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
