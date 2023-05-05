namespace NewsSpotAPI.BusinessLogic.Requests;

public class CreateNewsRequest : IRequest
{
    public List<RssItem> RssItems{ get; set; }
}
