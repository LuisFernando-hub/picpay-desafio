using Microsoft.EntityFrameworkCore;
using picpay_desafio.Models;

namespace picpay_desafio.Infra
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }

        public DbSet<CarteiraEntity?> Wallets { get; set; }
        public DbSet<TransferenciaEntity?> Transfers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarteiraEntity>()
                .HasIndex(w => new { w.document, w.email })
                .IsUnique();

            modelBuilder.Entity<CarteiraEntity>()
                .Property(t => t.amount_account)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<CarteiraEntity>()
                .Property(w => w.userType)
                .HasConversion<string>();

            modelBuilder.Entity<TransferenciaEntity>()
                .HasKey(t => t.transaction_id);

            modelBuilder.Entity<TransferenciaEntity>()
                .HasOne(t => t.sender)
                .WithMany()
                .HasForeignKey(t => t.sender_id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Transaction_Sender");

            modelBuilder.Entity<TransferenciaEntity>()
                .Property(t => t.amount)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<TransferenciaEntity>()
                .HasOne(t => t.receiver)
                .WithMany()
                .HasForeignKey(t => t.receiver_id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Transaction_Receiver");
        }
    }
}
