using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PuppyYoga.Data;
using PuppyYoga.Migrations;
using PuppyYoga.Models;

namespace PuppyYoga.Pages.YogaClasses
{
    public class IndexModel : PageModel
    {
        private readonly PuppyYoga.Data.PuppyYogaContext _context;

        public IndexModel(PuppyYoga.Data.PuppyYogaContext context)
        {
            _context = context;
        }

        public IList<YogaClass> YogaClass { get; set; } = default!;
        public YogaClassData YogaC { get; set; }
        public string ClassNameSort { get; set; }
        public string InstructorSort { get; set; }

        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(string sortOrder, string searchString)
        {

            YogaC = new YogaClassData();
            ClassNameSort = sortOrder == "classname" ? "classname_desc" : "classname";
            InstructorSort = sortOrder == "instructor" ? "instructor_desc" : "instructor";

            CurrentFilter = searchString;
           
            YogaC.YogaClasses = _context.YogaClasses
                                          .Include(y => y.Instructor)
                                          .Include(y => y.PuppySessions)
                                          .ThenInclude(y => y.Session)
                                          .AsNoTracking();

           if (!String.IsNullOrEmpty(searchString))
            {
                YogaC.YogaClasses = YogaC.YogaClasses.Where( s=> s.Instructor
                .FirstName.Contains(searchString) || s.Instructor.LastName.Contains(searchString)
                || s.ClassName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "classname_desc":
                    YogaC.YogaClasses = YogaC.YogaClasses.OrderByDescending(s => s.ClassName);
                    break;
                case "instructor_desc":
                    YogaC.YogaClasses = YogaC.YogaClasses.OrderByDescending(s => s.Instructor.FullName);
                    break;
                case "instructor":
                    YogaC.YogaClasses = YogaC.YogaClasses.OrderBy(s => s.Instructor.FullName);
                    break;
                default:
                    YogaC.YogaClasses = YogaC.YogaClasses.OrderBy(s => s.ClassName);
                    break;
            }

          
           
            YogaClass = YogaC.YogaClasses.ToList();
        }

    }
    
}
