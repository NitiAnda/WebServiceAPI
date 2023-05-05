namespace NewsSpotAPI.DataAccess.Context;

internal class DbInitializer
{
    private static readonly IRssParserService _rssParserService = new RssParserService();

    internal static void Initialize(NewsSpotContext dbContext)
    {
        if (dbContext == null)
            throw new ArgumentNullException(nameof(dbContext));

        dbContext.Database.EnsureCreated();

        if (!dbContext.RssChannel.Any() && !dbContext.RssItem.Any())
        {
            var (news,publisher) = _rssParserService.GetAllNewsAndPublisher();
            dbContext.RssChannel.AddRange(publisher);
            dbContext.RssItem.AddRange(news);
            dbContext.SaveChanges();
        }
    }
}
