namespace BookListRazor.Pages.BookList
{
    using BookListRazor.Model;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Threading.Tasks;

    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public EditModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task OnGet(int id)
        {
            this.Book = await this.db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToPage();
            }

            var bookFromDb = await this.db.Book.FindAsync(this.Book.Id);
            bookFromDb.Name = this.Book.Name;
            bookFromDb.Author = this.Book.Author;
            bookFromDb.ISBN = this.Book.ISBN;

            await this.db.SaveChangesAsync();

            this.Message = "Book has been updated successfully";

            return this.RedirectToPage("Index");
        }
    }
}