using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pobreTITO_Models;
using pobreTITO;

namespace pobreTITO_Services
{
    public static class ReportService
    {
        private static PobretitoDbContext context;
        public static void SetContext(IApplicationBuilder app) { context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<PobretitoDbContext>(); }
        public static List<Report> GetReports(User user) => context.Reports.Where(x => x.User == user).ToList<Report>();    
        public static async void PostReport(ReportViewModel model)
        {
            Report report = new();
            report.Address = model.Address;
            report.User = model.User;
            report.Type = (ReportType)model.ReportType;
            report.Comment = model.Comment;
            report.ImageURL = model.ImageURL;
            context.Reports.Add(report); context.SaveChanges();
        }
    }
}