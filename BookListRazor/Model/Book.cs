namespace BookListRazor.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Book Name")]
        public string Name { get; set; }

        public string ISBN { get; set; }

        public string Author { get; set; }
    }
}
