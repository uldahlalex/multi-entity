using Infra;
using LinqToDB;
using Service;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Data Source=db.db";
var options = new DataOptions().UseSQLite(connectionString);
var dataOptions = new DataOptions<MyDatabaseConnection>(options);
builder.Services.AddScoped<LibraryService>();
builder.Services.AddScoped<MyDatabaseConnection>(_ => new MyDatabaseConnection(dataOptions));

builder.Services.AddControllers();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MyDatabaseConnection>();
    db.CreateTable<Book>(tableOptions:TableOptions.CreateIfNotExists);
    if (db.Books.Count() == 0)
    {
        db.Insert(new Book()
        {
            Id = "1",
            Title = "Bobs book"
        });
    }
  
}

app.MapControllers();

app.Run();
