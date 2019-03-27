using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GingerPluginWebsite.Models
{
    public partial class GingerPluginDBContext : DbContext
    {
        public GingerPluginDBContext()
        {
        }

        public GingerPluginDBContext(DbContextOptions<GingerPluginDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Plugins> Plugins { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<VersionInfo> VersionInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("User ID=Ginger;Password=Automation123;Host=localhost;Port=5432;Database=GingerPluginDB;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Plugins>(entity =>
            {
                entity.HasKey(e => e.PluginId)
                    .HasName("Plugins_pkey");

                entity.Property(e => e.PluginId).HasColumnName("PluginID");

                entity.Property(e => e.Description).HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.PublisherId).HasColumnName("PublisherID");

                entity.Property(e => e.RepoUrl).HasColumnType("character varying");

                entity.Property(e => e.Type).HasColumnType("character varying");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("character varying");

                entity.Property(e => e.Website).HasColumnType("character varying");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.Property(e => e.PublisherId)
                    .HasColumnName("PublisherID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Emailid)
                    .IsRequired()
                    .HasColumnName("emailid")
                    .HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("character varying");

                entity.Property(e => e.Secret)
                    .HasColumnName("secret")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<VersionInfo>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("VersionInfo_pkey");

                entity.Property(e => e.ChangeLog).HasColumnType("character varying");

                entity.Property(e => e.FilePath).HasColumnType("character varying");

                entity.Property(e => e.MaxGingerVersion).HasColumnType("character varying");

                entity.Property(e => e.MinGingerVersion).HasColumnType("character varying");

                entity.Property(e => e.PluginId).HasColumnName("PluginID");

                entity.Property(e => e.PublishDate).HasColumnType("date");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasColumnType("character varying");
            });
        }
    }
}
