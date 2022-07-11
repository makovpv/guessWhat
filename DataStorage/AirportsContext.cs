using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataStorage
{
    public partial class AirportsContext : DbContext
    {
        public AirportsContext()
        {
        }

        public AirportsContext(DbContextOptions<AirportsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airport> Airports { get; set; } = null!;
        public virtual DbSet<Distance> Distances { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=c:\\\\\\\\projects\\pet\\data\\Airports.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>(entity =>
            {
                entity.ToTable("airports");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.Altitude)
                    .HasColumnType("int")
                    .HasColumnName("altitude");

                entity.Property(e => e.City)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("country");

                entity.Property(e => e.IataCode)
                    .HasColumnType("char(3)")
                    .HasColumnName("iata_code");

                entity.Property(e => e.IcaoCode)
                    .HasColumnType("char(4)")
                    .HasColumnName("icao_code");

                entity.Property(e => e.LatDecimal)
                    .HasColumnType("double")
                    .HasColumnName("lat_decimal");

                entity.Property(e => e.LatDeg)
                    .HasColumnType("int")
                    .HasColumnName("lat_deg");

                entity.Property(e => e.LatDir)
                    .HasColumnType("char(1)")
                    .HasColumnName("lat_dir");

                entity.Property(e => e.LatMin)
                    .HasColumnType("int")
                    .HasColumnName("lat_min");

                entity.Property(e => e.LatSec)
                    .HasColumnType("int")
                    .HasColumnName("lat_sec");

                entity.Property(e => e.LonDecimal)
                    .HasColumnType("double")
                    .HasColumnName("lon_decimal");

                entity.Property(e => e.LonDeg)
                    .HasColumnType("int")
                    .HasColumnName("lon_deg");

                entity.Property(e => e.LonDir)
                    .HasColumnType("char(1)")
                    .HasColumnName("lon_dir");

                entity.Property(e => e.LonMin)
                    .HasColumnType("int")
                    .HasColumnName("lon_min");

                entity.Property(e => e.LonSec)
                    .HasColumnType("int")
                    .HasColumnName("lon_sec");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("name");

                entity.Property(e => e.RunwayLength).HasColumnName("runway_length");

                entity.Property(e => e.RunwayWidth).HasColumnName("runway_width");
            });

            modelBuilder.Entity<Distance>(entity =>
            {
                entity.ToTable("distances");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AirportFromId).HasColumnName("airport_from_id");

                entity.Property(e => e.AirportToId).HasColumnName("airport_to_id");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
