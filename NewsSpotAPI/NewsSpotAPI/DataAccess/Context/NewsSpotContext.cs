namespace NewsSpotAPI.DataAccess.Context
{
    public class NewsSpotContext : DbContext
    {
        public DbSet<RssItem>? RssItem { get; set; }
        public DbSet<RssChannel>? RssChannel { get; set; }

        public NewsSpotContext(DbContextOptions<NewsSpotContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
