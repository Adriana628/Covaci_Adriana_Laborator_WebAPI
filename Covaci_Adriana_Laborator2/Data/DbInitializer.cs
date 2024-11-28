using Microsoft.EntityFrameworkCore;
using Covaci_Adriana_Laborator2.Models;
using System.Net;
using System.Security.Policy;

namespace Covaci_Adriana_Laborator2.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService
            <DbContextOptions<LibraryContext>>()))
            {
                if (context.Book.Any())
                {
                    return; // BD a fost creata anterior
                }
                var authors = new Author[]
                {
                 new Author{FirstName="Mihail",LastName="Sadoveanu"},
                 new Author{FirstName="George",LastName="Calinescu"},
                 new Author{FirstName="Mircea",LastName="Eliade"},
                 new Author{FirstName="Cella",LastName="Serghi"},
                 new Author{FirstName="Guillame",LastName="Musso"},
                 new Author{FirstName="Jerome David",LastName="Salinger"}
                };
                foreach (Author a in authors)
                {
                    context.Author.Add(a);
                }
                context.SaveChanges();
                var books = new Book[]
                {
                     new Book{Title="Baltagul",AuthorID=authors.Single(c => c.LastName =="Sadoveanu").ID, Price=Decimal.Parse("22")},
                     new Book{Title="Enigma Otiliei",AuthorID=authors.Single(c => c.LastName =="Calinescu").ID,Price=Decimal.Parse("18")},
                     new Book{Title="Maytrei",AuthorID=authors.Single(c => c.LastName == "Eliade").ID, Price=Decimal.Parse("27")},
                     new Book{Title="Panza de paianjen",AuthorID=authors.Single(c => c.LastName =="Serghi").ID, Price=Decimal.Parse("45")},
                     new Book{Title="Fata de hartie",AuthorID=authors.Single(c => c.LastName =="Musso").ID,Price=Decimal.Parse("38")},
                     new Book{Title="De veghe in lanul de secara",AuthorID=authors.Single(c => c.LastName== "Salinger").ID,Price=Decimal.Parse("28")},
 };
                foreach (Book b in books)
                {
                    context.Book.Add(b);
                }
                context.SaveChanges();
                var customers = new Customer[]
                {
                     new Customer{Name="Popescu Marcela",Adress="Str. Plopilor 25, Ploiesti",BirthDate=DateTime.Parse("1979-09-01")},
                     new Customer{Name="Mihailescu Cornel",Adress="Str. M. Eminescu 5, ClujNapoca",BirthDate=DateTime.Parse("1969-07-08")},
                };
                foreach (Customer c in customers)
                {
                    context.Customer.Add(c);
                }
                context.SaveChanges();
                var orders = new Order[]
                {
                 new Order{BookID=1,CustomerID=customers.Single(c => c.Name == "Popescu Marcela").CustomerID,OrderDate=DateTime.Parse("2024-02-25")},
                 new Order{BookID=3,CustomerID=customers.Single(c => c.Name == "Popescu Marcela").CustomerID,OrderDate=DateTime.Parse("2024-09-28")},
                 new Order{BookID=1,CustomerID=customers.Single(c => c.Name == "Popescu Marcela").CustomerID,OrderDate=DateTime.Parse("2024-10-28")},
                 new Order{BookID=2,CustomerID=customers.Single(c => c.Name == "Mihailescu Cornel").CustomerID,OrderDate=DateTime.Parse("2024-09-28")},
                 new Order{BookID=4,CustomerID=customers.Single(c => c.Name == "Mihailescu Cornel").CustomerID,OrderDate=DateTime.Parse("2024-09-28")},
                 new Order{BookID=6,CustomerID=customers.Single(c => c.Name == "Mihailescu Cornel").CustomerID,OrderDate=DateTime.Parse("2024-10-28")}, };
             foreach (Order e in orders)
                {
                    context.Order.Add(e);
                }
                context.SaveChanges();
                var publishers = new Models.Publisher[]
                {
                     new Covaci_Adriana_Laborator2.Models.Publisher{PublisherName="Humanitas",Adress="Str. Aviatorilor, nr. 40, Bucuresti"},
                     new Covaci_Adriana_Laborator2.Models.Publisher{PublisherName="Nemira",Adress="Str. Plopilor, nr. 35, Ploiesti"},
                     new Covaci_Adriana_Laborator2.Models.Publisher{PublisherName="Paralela 45",Adress="Str. Cascadelor, nr. 22, ClujNapoca"},
};
                foreach (Models.Publisher p in publishers)
                {
                    context.Publisher.Add(p);
                }
                context.SaveChanges();
                var publishedbooks = new PublishedBooks[]
                {
             new PublishedBooks {
                     BookID = books.Single(c => c.Title == "Maytrei" ).ID,
                     PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID
             },
             new PublishedBooks {
                     BookID = books.Single(c => c.Title == "Enigma Otiliei" ).ID,
                     PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID
             },
             new PublishedBooks {
                     BookID = books.Single(c => c.Title == "Baltagul" ).ID,
                     PublisherID = publishers.Single(i => i.PublisherName == "Nemira").ID
             },
             new PublishedBooks {
                     BookID = books.Single(c => c.Title == "Fata de hartie" ).ID,
                     PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID
             },
             new PublishedBooks {
                 BookID = books.Single(c => c.Title == "Panza de paianjen" ).ID,
                 PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID
             },
             new PublishedBooks {
                 BookID = books.Single(c => c.Title == "De veghe in lanul de secara" ).ID,
                 PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID
             },
 };
                foreach (PublishedBooks pb in publishedbooks)
                {
                    context.PublishedBooks.Add(pb);
                }
                context.SaveChanges();
            }
        }
    }
}


                              