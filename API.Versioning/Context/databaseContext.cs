namespace API.Versioning.Context
{
    public class databaseContext : DbContext
    {
        public databaseContext(DbContextOptions<databaseContext> options) : base(options)
        {

        }

        public DbSet<DriverInfo> DriverInfos { get; set; }
        public DbSet<AchivementInfo> AchivementInfos { get; set; }
    }
}
