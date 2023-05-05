namespace NewSpotAPI.DataAccess.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly NewsSpotContext _dbContext;
        private bool disposedValue;

        public IBaseRepository<RssItem, int> RssItemRepository { get; set; }
        public IBaseRepository<RssChannel, int> RssChannelRepository { get; set; }


        public UnitOfWork(
            NewsSpotContext dbContext,
            IBaseRepository<RssItem, int> rssItemRepository,
            IBaseRepository<RssChannel, int> rssChannelRepository)


        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            RssItemRepository =
                rssItemRepository
                ?? throw new ArgumentNullException(nameof(rssItemRepository));
            RssChannelRepository =
                rssChannelRepository ?? throw new ArgumentNullException(nameof(rssChannelRepository));
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext?.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
