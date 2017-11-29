using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlockchainAnalysisTool.Models
{
    public partial class GEN_BLKContext : DbContext
    {
        public virtual DbSet<Addr> Addr { get; set; }
        public virtual DbSet<Input> Input { get; set; }
        public virtual DbSet<Output> Output { get; set; }
        public virtual DbSet<Trans> Trans { get; set; }
        public virtual DbSet<WalletId> WalletId { get; set; }

        public GEN_BLKContext(DbContextOptions<GEN_BLKContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addr>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("PK_Addr");

                entity.Property(e => e.Aid).HasColumnName("AID");

                entity.Property(e => e.LastSentFrom).HasColumnType("varchar(50)");

                entity.Property(e => e.LastSentTo).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Input>(entity =>
            {
                entity.HasKey(e => e.IndexIn)
                    .HasName("PK_Input");

                entity.Property(e => e.Aid).HasColumnName("AID");

                entity.Property(e => e.Tid).HasColumnName("TID");
            });

            modelBuilder.Entity<Output>(entity =>
            {
                entity.HasKey(e => e.IndexOut)
                    .HasName("PK_Output");

                entity.Property(e => e.Aid).HasColumnName("AID");

                entity.Property(e => e.Tid).HasColumnName("TID");
            });

            modelBuilder.Entity<Trans>(entity =>
            {
                entity.HasKey(e => e.Tid)
                    .HasName("PK_Trans");

                entity.Property(e => e.Tid).HasColumnName("TID");
            });

            modelBuilder.Entity<WalletId>(entity =>
            {
                entity.HasKey(e => e.Wid)
                    .HasName("PK_WalletID");

                entity.ToTable("WalletID");

                entity.Property(e => e.Wid).HasColumnName("WID");
            });
        }
    }
}