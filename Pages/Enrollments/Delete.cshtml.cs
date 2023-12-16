using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PuppyYoga.Data;
using PuppyYoga.Models;

namespace PuppyYoga.Pages.Enrollments
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly PuppyYoga.Data.PuppyYogaContext _context;

        public DeleteModel(PuppyYoga.Data.PuppyYogaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Enrollment Enrollment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Enrollment == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment.Include(b => b.User).Include(b => b.YogaClass).FirstOrDefaultAsync(m => m.EnrollmentID == id);

            if (enrollment == null)
            {
                return NotFound();
            }
            else 
            {
                Enrollment = enrollment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.PuppySessions)
                .FirstOrDefaultAsync(m => m.EnrollmentID == id);

            if (enrollment != null)
            {
                // Remove related PuppySession records first
                foreach (var session in enrollment.PuppySessions.ToList())
                {
                    _context.PuppySession.Remove(session);
                }

                // Then remove the Enrollment
                _context.Enrollment.Remove(enrollment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

    }
}
