namespace NewsSpotAPI.Extensions;

internal static class DbInitializerExtension
{
    public static IApplicationBuilder SeedSqlServer(this IApplicationBuilder app)
    {
        if (app == null)
            throw new ArgumentNullException(nameof(app));

        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<NewsSpotContext>();

        DbInitializer.Initialize(context);

        return app;
    }
}
