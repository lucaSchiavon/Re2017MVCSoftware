namespace Re2017MVC
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<House> House { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modifica luca
            modelBuilder.Entity<House>().HasKey(p => p.Id);
            modelBuilder.Entity<House>()
              .Property(e => e.Id)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //---------------------
            modelBuilder.Entity<House>()
                .Property(e => e.street)
                .IsFixedLength();

            modelBuilder.Entity<House>()
                .Property(e => e.purchasePrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<House>()
                .Property(e => e.sqFeetPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<House>()
                .Property(e => e.grossRent)
                .HasPrecision(19, 4);

            modelBuilder.Entity<House>()
                .Property(e => e.percVacancy)
                .HasPrecision(18, 0);

            modelBuilder.Entity<House>()
                .Property(e => e.extimateAccountingExpense)
                .HasPrecision(19, 4);

            modelBuilder.Entity<House>()
                .Property(e => e.extimateCondoExpense)
                .HasPrecision(19, 4);

            modelBuilder.Entity<House>()
                .Property(e => e.extimateInsuranceExpense)
                .HasPrecision(19, 4);

            modelBuilder.Entity<House>()
                .Property(e => e.extimateMaintenanceExpense)
                .HasPrecision(19, 4);

            modelBuilder.Entity<House>()
                .Property(e => e.extimateProperyManagerExpense)
                .HasPrecision(19, 4);

            modelBuilder.Entity<House>()
                .Property(e => e.extimateUtilitiesExpense)
                .HasPrecision(19, 4);

            modelBuilder.Entity<House>()
                .Property(e => e.extimatePestControlExpense)
                .HasPrecision(19, 4);

            modelBuilder.Entity<House>()
                .Property(e => e.extimatePropertyTax)
                .HasPrecision(19, 4);

            modelBuilder.Entity<House>()
                .Property(e => e.closingCosts)
                .HasPrecision(19, 4);

            modelBuilder.Entity<House>()
                .Property(e => e.titleCompanyCosts)
                .HasPrecision(19, 4);

            modelBuilder.Entity<House>()
                .Property(e => e.agencyCosts)
                .HasPrecision(19, 4);

            modelBuilder.Entity<House>()
                .Property(e => e.otherClosingCosts)
                .HasPrecision(19, 4);
        }
    }
}
