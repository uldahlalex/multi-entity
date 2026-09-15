using Infra;
using Infra.Entities;
using LinqToDB;

namespace API;

public class MySeeder(MyDatabaseConnection db)
{
    public void Seed()
    {
        db.CreateTable<Book>(tableOptions: TableOptions.CreateIfNotExists);
        db.CreateTable<Author>(tableOptions: TableOptions.CreateIfNotExists);
        if (db.Authors.Count() == 0)
            db.Insert(new Author()
            {
                AuthorId = "1",
                AuthorName = "Bob"
            });
        if (db.Books.Count() == 0)
            db.Insert(new Book
            {
                Id = "1",
                Title = "Bobs book",
                AuthorId = "1"
            });
        //Valgfrit: Indsæt mere data, eventuelt i et loop så der er rigtig meget
    }
}