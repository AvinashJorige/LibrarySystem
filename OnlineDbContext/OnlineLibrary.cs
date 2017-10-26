namespace OnlineDbRepo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using EntityCore.Mappings;

    public partial class OnlineLibrary : DbContext
    {
        public OnlineLibrary()
            : base("name=OnlineLibraryEntity")
        {
        }

        static OnlineLibrary()
        {
            Database.SetInitializer<OnlineLibrary>(null);
        }

        public DbSet<EntityCore.Mappings.AdminMst> AdminMst { get; set; }
        public DbSet<EntityCore.Mappings.BookMst> BookMst { get; set; }
        public DbSet<EntityCore.Mappings.BranchMst> BranchMst { get; set; }
        public DbSet<EntityCore.Mappings.PenaltyMst> PenaltyMst { get; set; }
        public DbSet<EntityCore.Mappings.PublicationMst> PublicationMst { get; set; }
        public DbSet<EntityCore.Mappings.RentMst> RentMst { get; set; }
        public DbSet<EntityCore.Mappings.StudentMst> StudentMst { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EntityCore.Mappings.AdminMst>();
            modelBuilder.Entity<EntityCore.Mappings.BookMst>();
            modelBuilder.Entity<EntityCore.Mappings.BranchMst>();
            modelBuilder.Entity<EntityCore.Mappings.PenaltyMst>();
            modelBuilder.Entity<EntityCore.Mappings.PublicationMst>();
            modelBuilder.Entity<EntityCore.Mappings.RentMst>();
            modelBuilder.Entity<EntityCore.Mappings.StudentMst>();
        }
    }
}
