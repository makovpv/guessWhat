using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataStorage
{
    public partial class MatchPlaneContext : DbContext
    {
        public MatchPlaneContext()
        {
        }

        public MatchPlaneContext(DbContextOptions<MatchPlaneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PlaneImage> PlaneImages { get; set; } = null!;
        public virtual DbSet<PlaneType> PlaneTypes { get; set; } = null!;
        public virtual DbSet<UserAnswer> UserAnswers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\Projects\\Pet\\Data\\MatchPlane.db");


            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaneImage>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.ToTable("PlaneImage");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.ImagePath).HasColumnName("image_path");

                entity.Property(e => e.PlaneId).HasColumnName("plane_id");
            });

            modelBuilder.Entity<PlaneType>(entity =>
            {
                entity.ToTable("PlaneType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<UserAnswer>(entity =>
            {
                entity.ToTable("UserAnswer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.PlaneId).HasColumnName("plane_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
