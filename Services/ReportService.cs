using Microsoft.AspNetCore.Identity;
using System.Data;
using pobreTITO_Models;
using pobreTITO;

namespace pobreTITO_Services
{
    public static class ReportService
    {
        private static PobretitoDbContext context;
        private static UserManager<User> userManager;
        public static void SetContext(IApplicationBuilder app)
        {
            context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<PobretitoDbContext>();
            userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<User>>();
        }
        public static ReportGetResponse GetReports(string userName)
        {
            ReportGetResponse response = new();
            if (context.Reports.Count() > 0)
            {
                /*User user = context.Users.Find(userName);*/
                // response.Reports = context.Reports.Where(x => x.User == user).ToList<Report>();
                response.StateExecution = true;
            }
            else
            {
                response.StateExecution = false;
            }


            return response;
        }
        public static async Task<ReportPostResponse> PostReport(ReportViewModel model)
        {
            ReportPostResponse response = new();
            response.StateExecution = false;
            User user = await userManager.FindByNameAsync(model.User);

            if (user != null)
            {
                var count = context.Reports.Count();

                Report report = new();
                report.Id = context.Reports.Count() + 1;
                report.Address = model.Address;
                report.Type = (ReportType)model.ReportType;
                report.Comment = model.Comment;
                report.ImageURL = model.ImageURL;
                
                user.Reports.Add(report);
                context.Update(user);       
                context.SaveChanges();

                response.Report = report;
                response.StateExecution = true;
            }
            return response;
        }
    }
}