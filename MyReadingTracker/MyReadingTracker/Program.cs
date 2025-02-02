using System.Text.Json.Serialization;
using ContosoPizza.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyReadingTracker.Data;
using MyReadingTracker.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    options.JsonSerializerOptions.DefaultIgnoreCondition =
        JsonIgnoreCondition.WhenWritingNull;
    
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryContext>((sp, options) =>
{
    if (builder.Environment.IsEnvironment("Local"))
    {
        options.UseInMemoryDatabase("library-api-in-memory");
    }
    else
    {
        var connectionString = builder.Configuration.GetConnectionString("Postgres");
        options.UseNpgsql(connectionString);
    }
    options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
});

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IReadingSessionService, ReadingSessionService>();
builder.Services.AddScoped<ISeriesService, SeriesService>();
builder.Services.AddScoped<IGenreService, GenreService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:5173");
            policy.AllowAnyOrigin();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.MapControllers();

app.CreateDbIfNotExists();

app.Run();