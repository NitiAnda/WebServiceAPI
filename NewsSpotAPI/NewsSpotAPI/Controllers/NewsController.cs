using NewsSpotAPI.Helpers;

namespace NewsSpotAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NewsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "ProductionVersion")]
        public string GetProductionVersion()
        {
            string[] versions = new string[] { "2.5.0-dev.1", "2.4.2-5354", "2.4.2-test.675", "2.4.1-integration.1" };
            string productionVersion = VersionHelper.GetProductionVersion(versions);
             
            return productionVersion;
        }

        [HttpPost(Name = "PostNews")]
        public void PostNews(List<RssItem>? rssItems)
        {

            _mediator.Send(new CreateNewsRequest { RssItems = rssItems });
           
        }


        [HttpGet(Name = "GetAllNewsByKeyWord")]
        public async Task<IEnumerable<RssItem>> GetAllNewsByKeyWord(string? keyWord)
        {
            var news = await _mediator.Send(new GetAllNewsByKeyWordRequest { KeyWord = keyWord });

            return news;
        }

        [HttpGet(Name = "GetAllNewsOderByPublishDate")]
        public async Task<IEnumerable<RssItem>> GetAllNewsOderByPublishDate()
        {
            var news = await _mediator.Send(new GetAllNewsOderByPublishDateRequest());
            return news;
        }

        [HttpGet(Name = "GetAllNewsOderByDescendingPublishDate")]
        public async Task<IEnumerable<RssItem>> GetAllNewsOderByDescendingPublishDate()
        {
            var news = await _mediator.Send(new GetAllNewsOderByDescendingPublishDateRequest());
            return news;
        }

        [HttpGet(Name = "GetAllNewsOderByTitle")]
        public async Task<IEnumerable<RssItem>> GetAllNewsOderByTitle()
        {
            var news = await _mediator.Send(new GetAllNewsOderByTitleRequest());
            return news;
        }

        [HttpGet(Name = "GetAllNewsOderByDescendingTitle")]
        public async Task<IEnumerable<RssItem>> GetAllNewsOderByDescendingTitle()
        {
            var news = await _mediator.Send(new GetAllNewsOderByDescendingTitleRequest());
            return news;
        }

    }
}
