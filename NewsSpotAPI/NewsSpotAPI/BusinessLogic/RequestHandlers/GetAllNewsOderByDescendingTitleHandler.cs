namespace NewsSpotAPI.BusinessLogic.RequestHandlers;

public class GetAllNewsOderByDescendingTitleHandler
    : IRequestHandler<GetAllNewsOderByDescendingTitleRequest, IEnumerable<RssItem>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllNewsOderByDescendingTitleHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<IEnumerable<RssItem>> Handle(
        GetAllNewsOderByDescendingTitleRequest request,
        CancellationToken cancellationToken
    )
    {
        var news = await _unitOfWork.RssItemRepository
            .GetAll()
            .OrderByDescending(n => n.Title)
            .ToListAsync(cancellationToken);

        return news;
    }
}
