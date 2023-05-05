namespace NewsSpotAPI.BusinessLogic.RequestHandlers;

public class GetAllNewsOderByPublishDateHandler
    : IRequestHandler<GetAllNewsOderByPublishDateRequest, IEnumerable<RssItem>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllNewsOderByPublishDateHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<IEnumerable<RssItem>> Handle(
        GetAllNewsOderByPublishDateRequest request,
        CancellationToken cancellationToken
    )
    {
        var news = await _unitOfWork.RssItemRepository
            .GetAll()
            .OrderBy(n => n.PublishDate)
            .ToListAsync(cancellationToken);

        return news;
    }
}
