using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PuppyYoga.Models;

namespace PuppyYoga.Pages.Instructors
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : PageModel
    {
        private readonly PuppyYoga.Data.PuppyYogaContext _context;

        public CreateModel(PuppyYoga.Data.PuppyYogaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Instructor Instructor { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Instructors.Add(Instructor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
