using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covaci_Adriana_Laborator2.Models
{
    /// <summary>
    /// id, first name, last name
    /// </summary>
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Book>? Books { get; set; }

        //public ICollection<Book> Books { get; set; } = new List<Book>();
        public string FullName => $"{FirstName} {LastName}";
    }
}
