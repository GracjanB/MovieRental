namespace DatabaseAccess.Model
{
    using DatabaseAccess.Entities;
    using DatabaseAccess.EntitiesConfiguration;
    using System.Data.Entity;

    public class MovieRentalModel : DbContext
    {
        public MovieRentalModel()
            : base(nameOrConnectionString: "MovieRentalDB")
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<VideoRental> VideoRentals { get; set; }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ReviewConfiguration());
            modelBuilder.Configurations.Add(new AccountConfiguration());
            modelBuilder.Configurations.Add(new VideoConfiguration());
            modelBuilder.Configurations.Add(new VideoRentalConfiguration());

            base.OnModelCreating(modelBuilder); 
        }
    }
}