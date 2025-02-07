using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RepairExam
{
    public partial class RepairServiceContext : DbContext
    {
        public RepairServiceContext()
        {
        }

        public RepairServiceContext(DbContextOptions<RepairServiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Заявка> Заявкаs { get; set; } = null!;
        public virtual DbSet<Исполнитель> Исполнительs { get; set; } = null!;
        public virtual DbSet<Клиент> Клиентs { get; set; } = null!;
        public virtual DbSet<Ремонт> Ремонтs { get; set; } = null!;
        public virtual DbSet<Статус> Статусs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-932LPHA\\SQLEXPRESS;Database=RepairService;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Заявка>(entity =>
            {
                entity.HasKey(e => e.Ун);

                entity.ToTable("Заявка");

                entity.Property(e => e.Ун).HasColumnName("УН");

                entity.Property(e => e.ДатаВыполнения)
                    .HasColumnType("datetime")
                    .HasColumnName("Дата выполнения");

                entity.Property(e => e.ДатаПодачи)
                    .HasColumnType("datetime")
                    .HasColumnName("Дата подачи");

                entity.Property(e => e.Статус)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ОтправительNavigation)
                    .WithMany(p => p.Заявкаs)
                    .HasForeignKey(d => d.Отправитель)
                    .HasConstraintName("FK_Заявка_Клиент");
            });

            modelBuilder.Entity<Исполнитель>(entity =>
            {
                entity.HasKey(e => e.Ун);

                entity.ToTable("Исполнитель");

                entity.Property(e => e.Ун).HasColumnName("УН");

                entity.Property(e => e.Инн)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ИНН");

                entity.Property(e => e.Паспорт)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Телефон)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Фио)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("ФИО");
            });

            modelBuilder.Entity<Клиент>(entity =>
            {
                entity.HasKey(e => e.Ун);

                entity.ToTable("Клиент");

                entity.Property(e => e.Ун).HasColumnName("УН");

                entity.Property(e => e.Телефон)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Фио)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("ФИО");
            });

            modelBuilder.Entity<Ремонт>(entity =>
            {
                entity.HasKey(e => e.Ун);

                entity.ToTable("Ремонт");

                entity.Property(e => e.Ун).HasColumnName("УН");

                entity.Property(e => e.Коментарий)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.ЗаявкаNavigation)
                    .WithMany(p => p.Ремонтs)
                    .HasForeignKey(d => d.Заявка)
                    .HasConstraintName("FK_Ремонт_Заявка");

                entity.HasOne(d => d.ИсполнительNavigation)
                    .WithMany(p => p.Ремонтs)
                    .HasForeignKey(d => d.Исполнитель)
                    .HasConstraintName("FK_Ремонт_Исполнитель");
            });

            modelBuilder.Entity<Статус>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Статус");

                entity.Property(e => e.Статус1)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Статус");

                entity.Property(e => e.Ун).HasColumnName("УН");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
