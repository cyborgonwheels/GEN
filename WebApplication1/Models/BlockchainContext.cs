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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=gen-sql.database.windows.net;Database=gen-blockchain-db;Trusted_Connection=False;Encrypt=True;User ID=up_blockchain;password=UPBl0ckChainSecurity2017!");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addr>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("PK_Addr");

                entity.Property(e => e.Aid)
                    .HasColumnName("AID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.LastReceivedFrom).HasColumnType("varchar(50)");

                entity.Property(e => e.LastSentTo).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<InputId>(entity =>
            {
                entity.HasKey(e => e.IndexIn)
                    .HasName("PK_InputID");

                entity.ToTable("InputID");

                entity.Property(e => e.Aid)
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