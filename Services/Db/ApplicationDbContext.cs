using CIS.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CIS.Db
{
    public partial class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Campaign> Campaigns { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Phone> Phones { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => new { e.IdClient, e.Address1 })
                    .HasName("PK__addresse__E1F7D83130DBE633");

                entity.ToTable("addresses");

                entity.Property(e => e.IdClient).HasColumnName("idClient");

                entity.Property(e => e.Address1)
                    .HasMaxLength(256)
                    .HasColumnName("address");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fd_clients");
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("campaigns");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creationDate");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creationDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastName)
                    .HasMaxLength(500)
                    .HasColumnName("lastName");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasKey(e => new { e.IdClient, e.PhoneNumber })
                    .HasName("PK__phones__B2228D74DEC65BB8");

                entity.ToTable("phones");

                entity.Property(e => e.IdClient).HasColumnName("idClient");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(256)
                    .HasColumnName("phoneNumber");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clients");
            });
        }
    }
}
