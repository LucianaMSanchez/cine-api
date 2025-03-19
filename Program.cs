using cineApi.Data;
using cineApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("CineApi");
builder.Services.AddSqlite<CineApiContext>(connString);

var app = builder.Build();

app.MapFunctionsEndpoints();

app.MigrateDb();

app.Run();
