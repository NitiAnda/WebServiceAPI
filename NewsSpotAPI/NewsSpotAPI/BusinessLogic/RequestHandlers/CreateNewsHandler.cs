namespace NewsSpotAPI.BusinessLogic.RequestHandlers;

public class CreateNewsHandler : IRequestHandler<CreateNewsRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateNewsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Unit> Handle(CreateNewsRequest request, CancellationToken cancellationToken)
    {
        var news = request.RssItems;

        await _unitOfWork.RssItemRepository.AddRangeAsync(news);

        _unitOfWork.Save(); 

        return Unit.Value;
    }
}
