namespace NewsSpotAPI.BusinessLogic.RequestHandlers;

public class GetAllNewsByKeyWordHandlercs
    : IRequestHandler<GetAllNewsByKeyWordRequest, IEnumerable<RssItem>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllNewsByKeyWordHandlercs(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<IEnumerable<RssItem>> Handle(
        GetAllNewsByKeyWordRequest request,
        CancellationToken cancellationToken
    )
    {
        var keyword = request.KeyWord;

        var news = await _unitOfWork.RssItemRepository
            .GetByFilter(n => n.Description.Contains(keyword) || n.Title.Contains(keyword))
            .ToListAsync(cancellationToken);

        return news;
    }
}
