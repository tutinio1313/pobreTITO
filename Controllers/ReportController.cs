using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using pobreTITO_Models;
using pobreTITO_Services;

#pragma warning disable 1998

namespace pobreTITO.Controllers;
public class ReportController : Controller
{
#pragma warning disable CS8618
    private readonly ILogger<ReportController> _logger;
#pragma warning restore CS8618

    public ReportController(ILogger<ReportController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("/Get")]
    public async Task<ReportGetResponse> GetReports(string userName) => ReportService.GetReports(userName);
    [HttpPost]
    public async Task<IActionResult> Post(ReportViewModel model)
    {
        await ReportService.PostReport(model);
        return RedirectToAction("Index", "User");
    }

}