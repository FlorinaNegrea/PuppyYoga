using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PuppyYoga.Data;
using PuppyYoga.Models;

namespace PuppyYoga.Pages.Enrollments
{
    public class CreateModel : PuppySessionsPageModel
    {
        private readonly PuppyYoga.Data.PuppyYogaContext _context;

        public CreateModel(PuppyYoga.Data.PuppyYogaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserID"] = new SelectList(_context.User, "UserID", "FullName");
        ViewData["YogaClassID"] = new SelectList(_context.YogaClasses, "YogaClassID", "ClassName");
            var enrollment = new Enrollment();
            enrollment.PuppySessions = new List<PuppySession>();
            PopulateAssignedSessionData(_context, enrollment);
            
            return Page();
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedSessions)
        {
            var newEnrollment = new Enrollment();
            if (selectedSessions != null)
            {
                newEnrollment.PuppySessions = new List<PuppySession>();
                foreach (var session in selectedSessions)
                {
                    var sessionToAdd = new PuppySession
                    {
                      
                        SessionId = int.Parse(session),
                        YogaClassID = Enrollment.YogaClassID

                    };
                    newEnrollment.PuppySessions.Add(sessionToAdd);
                }
            }
            Enrollment.PuppySessions = newEnrollment.PuppySessions;
            _context.Enrollment.Add(Enrollment);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
