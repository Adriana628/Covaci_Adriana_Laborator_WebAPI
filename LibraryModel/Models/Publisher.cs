using System.ComponentModel.DataAnnotations;
namespace Covaci_Adriana_Laborator2.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Publisher Name")]
        [StringLength(50)]
        public string PublisherName { get; set; }

        [StringLength(70)]
        public string Adress { get; set; }
        public ICollection<PublishedBooks>? PublishedBooks { get; set; }
    }
}
