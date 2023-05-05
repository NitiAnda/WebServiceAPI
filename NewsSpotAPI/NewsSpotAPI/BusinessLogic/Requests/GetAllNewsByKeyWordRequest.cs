namespace NewsSpotAPI.BusinessLogic.Requests;

public class GetAllNewsByKeyWordRequest : IRequest<IEnumerable<RssItem>>
{
    public string KeyWord { get; set; }
}
