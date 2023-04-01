using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dip
{
    public partial class EfModel : DbContext
    {
        private static EfModel _instance;
        public static EfModel Init()=>_instance ?? (_instance = new EfModel());
        public EfModel()
        {
        }

        public EfModel(DbContextOptions<EfModel> options)
            : base(options)
        {
        }

        public virtual DbSet<Access> Accesses { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; } = null!;
        public virtual DbSet<Note> Notes { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=cfif31.ru;port=3306;user id=ISPr22-43_UrazovMM;password=ISPr22-43_UrazovMM;database=ISPr22-43_UrazovMM_praktika1;character set=utf8", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Access>(entity =>
            {
                entity.HasKey(e => e.IdAccess)
                    .HasName("PRIMARY");

                entity.ToTable("Access");

                entity.Property(e => e.IdAccess).HasColumnName("idAccess");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.HasIndex(e => e.WorkerWorkerId, "IX_Worker_WorkerID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.Property(e => e.WorkerWorkerId).HasColumnName("Worker_WorkerID");

                entity.HasOne(d => d.WorkerWorker)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.WorkerWorkerId);
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId)
                    .HasMaxLength(150)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.ContextKey)
                    .HasMaxLength(300)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.ProductVersion)
                    .HasMaxLength(32)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => e.IdNote)
                    .HasName("PRIMARY");

                entity.ToTable("Note");

                entity.HasIndex(e => e.ClientClientId, "IX_Client_ClientID");

                entity.Property(e => e.IdNote).HasColumnName("idNote");

                entity.Property(e => e.ClientClientId).HasColumnName("Client_ClientID");

                entity.HasOne(d => d.ClientClient)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.ClientClientId);
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.ToTable("Worker");

                entity.Property(e => e.WorkerId).HasColumnName("WorkerID");

                entity.Property(e => e.NameWorker)
                    .HasMaxLength(128)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
