namespace NewsSpotAPI.Extensions;

internal static class UseRepositoriesExtension
{
    public static IServiceCollection UseRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBaseRepository<RssItem, int>, BaseRepository<RssItem, int>>();
        services.AddScoped<IBaseRepository<RssChannel, int>, BaseRepository<RssChannel, int>>();

        return services;
    }
}
