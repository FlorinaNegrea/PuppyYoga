using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PuppyYoga.Data;
using PuppyYoga.Models;
using PuppyYoga.Models.ViewModels;

namespace PuppyYoga.Pages.Instructors
{
    public class IndexModel : PageModel
    {
        private readonly PuppyYoga.Data.PuppyYogaContext _context;

        public IndexModel(PuppyYoga.Data.PuppyYogaContext context)
        {
            _context = context;
        }

        public IList<Instructor> Instructor { get;set; } = default!;

        public InstructorIndexData InstructorData { get; set; }
        public int InstructorId { get; set; }
        public int YogaClassID { get; set; }
        public async Task OnGetAsync(int? id,int? yogaclassID)
        {
            InstructorData = new InstructorIndexData();
            InstructorData.Instructors = await _context.Instructors.
                Include(i => i.YogaClasses).OrderBy(i => i.InstructorId).ToListAsync();
              if(id != null)
            {
                InstructorId = id.Value;
                Instructor instructor = InstructorData.Instructors.Where
                    (i => i.InstructorId == id.Value).Single();
                InstructorData.YogaClasses = instructor.YogaClasses;
            }
            if (_context.Instructors != null)
            {
                Instructor = await _context.Instructors.ToListAsync();
            }
        }
    }
}
