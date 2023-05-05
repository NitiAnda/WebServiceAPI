namespace NewsSpotAPI.Services;

public interface IRssParserService
{
    Tuple<List<RssItem>, RssChannel> GetAllNewsAndPublisher();
}