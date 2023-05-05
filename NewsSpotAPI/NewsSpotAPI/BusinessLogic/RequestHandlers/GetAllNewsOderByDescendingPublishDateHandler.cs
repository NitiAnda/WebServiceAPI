namespace NewsSpotAPI.BusinessLogic.RequestHandlers;

public class GetAllNewsOderByDescendingPublishDateHandler
    : IRequestHandler<GetAllNewsOderByDescendingPublishDateRequest, IEnumerable<RssItem>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllNewsOderByDescendingPublishDateHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<IEnumerable<RssItem>> Handle(
        GetAllNewsOderByDescendingPublishDateRequest request,
        CancellationToken cancellationToken
    )
    {
        var news = await _unitOfWork.RssItemRepository
            .GetAll()
            .OrderByDescending(n => n.PublishDate)
            .ToListAsync(cancellationToken);

        return news;
    }
}
