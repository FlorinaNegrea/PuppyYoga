using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PuppyYoga.Data;
using PuppyYoga.Models;

namespace PuppyYoga.Pages.Enrollments
{
    [Authorize(Roles = "Admin")]

    public class EditModel : PuppySessionsPageModel
    {
        private readonly PuppyYoga.Data.PuppyYogaContext _context;

        public EditModel(PuppyYoga.Data.PuppyYogaContext context)
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

            var enrollment =  await _context.Enrollment
                .Include(b => b.User)
                .Include(b => b.PuppySessions).ThenInclude(b => b.Session)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.EnrollmentID == id);
            if (enrollment == null)
            {
                return NotFound();
            }
            PopulateAssignedSessionData(_context, Enrollment);
            Enrollment = enrollment;
           ViewData["UserID"] = new SelectList(_context.User, "UserID", "FullName");
           ViewData["YogaClassID"] = new SelectList(_context.YogaClasses, "YogaClassID", "ClassName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedSessions)
        {
            if (id == null)
            {
                return NotFound();
            }
            var classToUpdate = await _context.Enrollment
                .Include(y => y.User)
                .Include(y => y.PuppySessions).ThenInclude(y => y.Session)
                .FirstOrDefaultAsync(m => m.YogaClassID == id);
            if (classToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Enrollment>(

                classToUpdate,
                "Enrollment",
                i => i.EnrollmentDate, i=> i.UserID, i=>i.YogaClassID
                ))
            {
                UpdatePuppySessions(_context, selectedSessions, classToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdatePuppySessions(_context, selectedSessions, classToUpdate);
            PopulateAssignedSessionData(_context, classToUpdate);
            return Page();
        }


        private bool EnrollmentExists(int id)
        {
          return (_context.Enrollment?.Any(e => e.EnrollmentID == id)).GetValueOrDefault();
        }
    }
}
