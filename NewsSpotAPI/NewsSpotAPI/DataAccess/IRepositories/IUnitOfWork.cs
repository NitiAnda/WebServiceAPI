namespace NewSpotAPI.DataAccess.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<RssItem, int> RssItemRepository { get; set; }
        IBaseRepository<RssChannel, int> RssChannelRepository { get; set; }
      
        void Save();
    }
}
