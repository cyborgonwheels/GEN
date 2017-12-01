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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=up-gen.database.windows.net;Database=GEN_BLK;Trusted_Connection=False;Encrypt=True;User ID=genblock;password=UPcapstone1!");
        }

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