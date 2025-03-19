using cineApi.Data;
using cineApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("CineApi");
builder.Services.AddSqlite<CineApiContext>(connString);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
var app = builder.Build();

app.UseCors("AllowLocalhost");

app.MapFunctionsEndpoints();
app.MapMoviesEndpoints();

app.MigrateDb();

app.Run();
