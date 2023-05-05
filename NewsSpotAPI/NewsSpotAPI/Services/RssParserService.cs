namespace NewsSpotAPI.Services
{
    public class RssParserService : IRssParserService
    {
        private string RssUrl { get; set; } = "https://rss.nytimes.com/services/xml/rss/nyt/World.xml";

        private RssChannel GetPublisher()
        {
            XDocument rssfeedxml;
            rssfeedxml = XDocument.Load(RssUrl);

            RssChannel publisher = new();

            foreach (var rss in rssfeedxml.Descendants("channel"))
            {
                if (DateTime.TryParse(rss.Element("pubDate")?.Value, out DateTime PublishDate))
                {
                    publisher = new RssChannel
                    {
                        Title = rss.Element("title")?.Value,
                        Link = rss.Element("link")?.Value,
                        PublishDate = PublishDate
                    };
                }
            }

            return publisher;
        }

        public Tuple<List<RssItem>, RssChannel> GetAllNewsAndPublisher()
        {
            XDocument rssfeedxml;
            rssfeedxml = XDocument.Load(RssUrl);

            List<RssItem> news = new();
            var publisher = GetPublisher();


            foreach (var rss in rssfeedxml.Descendants("item"))
            {
                if (DateTime.TryParse(rss.Element("pubDate")?.Value, out DateTime PublishDate))
                {
                    RssItem rssItem = new()
                    {
                        Title = rss.Element("title")?.Value,
                        Link = rss.Element("link")?.Value,
                        Description = rss.Element("description")?.Value,
                        PublishDate = PublishDate,
                        ChannelId = publisher.Id,
                        Channel = publisher
                    };
                    news.Add(rssItem);
                }
            }

            return Tuple.Create(news, publisher);
        }
    }
}
