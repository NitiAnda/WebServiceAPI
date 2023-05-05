namespace NewsSpotAPI.BusinessLogic.RequestHandlers;

public class GetAllNewsOderByTitleHnadlercs
    : IRequestHandler<GetAllNewsOderByTitleRequest, IEnumerable<RssItem>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllNewsOderByTitleHnadlercs(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<IEnumerable<RssItem>> Handle(
        GetAllNewsOderByTitleRequest request,
        CancellationToken cancellationToken
    )
    {
        var news = await _unitOfWork.RssItemRepository
            .GetAll()
            .OrderBy(n => n.Title)
            .ToListAsync(cancellationToken);

        return news;
    }
}
