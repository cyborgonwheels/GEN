using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlockchainAnalysisTool.Models
{
    public partial class BlockchainContext : DbContext
    {
        public virtual DbSet<Addr> Addr { get; set; }
        public virtual DbSet<InputId> InputId { get; set; }
        public virtual DbSet<OutputId> OutputId { get; set; }
        public virtual DbSet<Trans> Trans { get; set; }
        public virtual DbSet<Wallet> Wallet { get; set; }

        public BlockchainContext(DbContextOptions<BlockchainContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addr>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("PK_Addr");

                entity.Property(e => e.Aid)
                    .HasColumnName("AID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.LastReceivedFrom)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.LastSentTo)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<InputId>(entity =>
            {
                entity.HasKey(e => e.IndexIn)
                    .HasName("PK_InputID");

                entity.ToTable("InputID");

                entity.Property(e => e.Aid)
                    .IsRequired()
                    .HasColumnName("AID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Tid).HasColumnName("TID");
            });

            modelBuilder.Entity<OutputId>(entity =>
            {
                entity.HasKey(e => e.IndexOut)
                    .HasName("PK_OutputID");

                entity.ToTable("OutputID");

                entity.Property(e => e.Aid)
                    .IsRequired()
                    .HasColumnName("AID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Tid).HasColumnName("TID");
            });

            modelBuilder.Entity<Trans>(entity =>
            {
                entity.HasKey(e => e.Tid)
                    .HasName("PK_Trans");

                entity.Property(e => e.Tid)
                    .HasColumnName("TID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.HasKey(e => e.Wid)
                    .HasName("PK_Wallet");

                entity.Property(e => e.Wid)
                    .HasColumnName("WID")
                    .ValueGeneratedNever();
            });
        }
    }
}