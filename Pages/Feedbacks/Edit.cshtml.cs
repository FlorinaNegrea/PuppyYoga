using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PuppyYoga.Data;
using PuppyYoga.Models;

namespace PuppyYoga.Pages.Feedbacks
{
    public class EditModel : PageModel
    {
        private readonly PuppyYoga.Data.PuppyYogaContext _context;

        public EditModel(PuppyYoga.Data.PuppyYogaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Feedback Feedback { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Feedback == null)
            {
                return NotFound();
            }

            var feedback =  await _context.Feedback.FirstOrDefaultAsync(m => m.FeedbackId == id);
            if (feedback == null)
            {
                return NotFound();
            }
            Feedback = feedback;
           ViewData["UserId"] = new SelectList(_context.User, "UserID", "UserID");
           ViewData["YogaClassID"] = new SelectList(_context.YogaClasses, "YogaClassID", "YogaClassID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Feedback).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(Feedback.FeedbackId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FeedbackExists(int id)
        {
          return (_context.Feedback?.Any(e => e.FeedbackId == id)).GetValueOrDefault();
        }
    }
}
