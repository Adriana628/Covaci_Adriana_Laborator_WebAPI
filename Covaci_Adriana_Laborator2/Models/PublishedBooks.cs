namespace Covaci_Adriana_Laborator2.Models
{
    public class PublishedBooks
    {
        public int ID { get; set; }
        public int PublisherID { get; set; }
        public int BookID { get; set; }
        public Publisher Publisher { get; set; }
        public Book Book { get; set; }
    }
}
