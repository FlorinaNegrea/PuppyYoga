using Microsoft.AspNetCore.Mvc.RazorPages;
using PuppyYoga.Data;

namespace PuppyYoga.Models
{
    public class PuppySessionsPageModel : PageModel
    {
        public List<AssignedSessionData> AssignedSessionDataList;
        public void PopulateAssignedSessionData(PuppyYogaContext context, Enrollment enrollment)
        {
            if (enrollment == null || enrollment.PuppySessions == null)
            {
                AssignedSessionDataList = new List<AssignedSessionData>();
                return;
            }
            var allSessions = context.Session;
            var classSessions = new HashSet<int>(
            enrollment.PuppySessions.Select(c => c.SessionId));
            AssignedSessionDataList = new List<AssignedSessionData>();

            foreach (var cat in allSessions)
            {
                AssignedSessionDataList.Add(new AssignedSessionData
                {
                    SessionId = cat.SessionId,
                    SessionName = cat.SessionName,
                    Assigned = classSessions.Contains(cat.SessionId)
                });
            }
        }
        public void UpdatePuppySessions(PuppyYogaContext context,
        string[] selectedSessions, Enrollment classToUpdate)
        {
            if (selectedSessions == null || selectedSessions.Length == 0)
            {
                classToUpdate.PuppySessions = new List<PuppySession>();
                return;
            }
            var selectedSessionsHS = new HashSet<string>(selectedSessions);
            var classSessions = new HashSet<int>
            (classToUpdate.PuppySessions.Select(c => c.Session.SessionId));
            foreach (var cat in context.Session)
            {
                if (selectedSessionsHS.Contains(cat.SessionId.ToString()))
                {
                    if (!classSessions.Contains(cat.SessionId))
                    {
                        classToUpdate.PuppySessions.Add(
                        new PuppySession
                        {
                            EnrollmentID = classToUpdate.EnrollmentID,
                            SessionId = cat.SessionId
                        });
                    }
                }
                else
                {
                    if (classSessions.Contains(cat.SessionId))
                    {
                        PuppySession courseToRemove
                        = classToUpdate
                        .PuppySessions
                        .SingleOrDefault(i => i.SessionId == cat.SessionId);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}