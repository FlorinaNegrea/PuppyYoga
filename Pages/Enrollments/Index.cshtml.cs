using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PuppyYoga.Data;
using PuppyYoga.Models;

namespace PuppyYoga.Pages.Enrollments
{
    public class IndexModel : PageModel
    {
        private readonly PuppyYoga.Data.PuppyYogaContext _context;

        public IndexModel(PuppyYoga.Data.PuppyYogaContext context)
        {
            _context = context;
        }

        public IList<Enrollment> Enrollment { get;set; } = default!;

        public SessionData EnrollmentD { get; set; }
        public int EnrollmentID { get; set; }
        public int SessionId { get; set; }

        public async Task OnGetAsync(int? id, int? sessionId)
        {
            EnrollmentD = new SessionData();


            EnrollmentD.Enrollments = await _context.Enrollment
            .Include(y => y.User)
            .Include(y =>y.YogaClass)
            .Include(y => y.PuppySessions)
            .ThenInclude(y => y.Session)
            .AsNoTracking()
            .OrderBy(y => y.EnrollmentDate)
            .ToListAsync();
            if (id != null)
            {
                EnrollmentID = id.Value;
                Enrollment enrollment = EnrollmentD.Enrollments
                    .Where(i => i.EnrollmentID == id.Value).Single();
                EnrollmentD.Sessions = enrollment.PuppySessions.Select(s => s.Session);
            }

        }
    }
}
