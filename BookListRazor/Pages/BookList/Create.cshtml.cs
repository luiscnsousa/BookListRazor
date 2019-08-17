namespace BookListRazor.Pages.BookList
{
    using BookListRazor.Model;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Threading.Tasks;

    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public CreateModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return this.Page();
            }

            this.db.Book.Add(this.Book);
            await this.db.SaveChangesAsync();

            return this.RedirectToPage("Index");
        }
    }
}