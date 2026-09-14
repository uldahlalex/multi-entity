using Infra;
using LinqToDB;
using Service;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Data Source=db.db";
var options = new DataOptions().UseSQLite(connectionString);
var dataOptions = new DataOptions<MyDatabaseConnection>(options);
builder.Services.AddScoped<LibraryService>();
builder.Services.AddScoped<MyDatabaseConnection>(_ => new MyDatabaseConnection(dataOptions));
builder.Services.AddOpenApiDocument();
builder.Services.AddControllers();
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(config => config.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().SetIsOriginAllowed(_ => true));
app.UseOpenApi();
app.UseSwaggerUi();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MyDatabaseConnection>();
    db.CreateTable<Book>(tableOptions:TableOptions.CreateIfNotExists);
    db.CreateTable<Author>(tableOptions:TableOptions.CreateIfNotExists);
    if (db.Authors.Count() == 0)
    {
        db.Insert(new Author()
        {
            AuthorId = "1",
            AuthorName = "Bob"
        });
    }
    if (db.Books.Count() == 0)
    {
        db.Insert(new Book()
        {
            Id = "1",
            Title = "Bobs book",
            AuthorId = "1"
        });
    }

  
    
  
}

app.MapControllers();

app.Run();
