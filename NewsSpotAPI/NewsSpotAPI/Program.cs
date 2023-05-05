var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NewsSpotApi", Version = "v1" });
});

var connectionString =
    builder.Configuration.GetConnectionString("NewsSpotDBConnection")
    ?? throw new InvalidOperationException("Connection string 'NewsSpotDBConnection' not found.");

builder.Services.AddDbContext<NewsSpotContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IRssParserService, RssParserService>();

builder.Services.AddScoped<DbInitializer>();

builder.Services.UseRepositories();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(typeof(EntryPointRequestHandlers));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NewsSpotApi v1"));
    app.SeedSqlServer();
}
app.UseErrorHandler();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

