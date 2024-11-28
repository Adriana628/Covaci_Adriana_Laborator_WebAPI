namespace Covaci_Adriana_Laborator2.Models.LibraryViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Order> Orders { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
    }
}
