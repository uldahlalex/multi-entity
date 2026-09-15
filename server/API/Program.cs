using API;
using Infra;
using LinqToDB;
using Service;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Data Source=db.db";
var options = new DataOptions().UseSQLite(connectionString);
var dataOptions = new DataOptions<MyDatabaseConnection>(options);
builder.Services.AddScoped<LibraryService>();
builder.Services.AddScoped<MyDatabaseConnection>(_ => new MyDatabaseConnection(dataOptions));
builder.Services.AddScoped<MySeeder>();
builder.Services.AddOpenApiDocument();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<MyExceptionHandler>();
builder.Services.AddControllers();
builder.Services.AddCors();

var app = builder.Build();

app.UseExceptionHandler();
app.UseCors(config => config.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().SetIsOriginAllowed(_ => true));
app.UseOpenApi();
app.UseSwaggerUi();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<MySeeder>();
    seeder.Seed();
}

app.MapControllers();

app.Run();