using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PuppyYoga.Data;
using PuppyYoga.Models;

namespace PuppyYoga.Pages.Feedbacks
{
    [Authorize(Roles = "User")]

    public class CreateModel : PageModel
    {
        private readonly PuppyYoga.Data.PuppyYogaContext _context;

        public CreateModel(PuppyYoga.Data.PuppyYogaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.User, "UserID", "FullName");
        ViewData["YogaClassID"] = new SelectList(_context.YogaClasses, "YogaClassID", "ClassName");
            return Page();
        }

        [BindProperty]
        public Feedback Feedback { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Feedback == null || Feedback == null)
            {
                return Page();
            }

            _context.Feedback.Add(Feedback);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
