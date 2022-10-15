using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using pobreTITO_Models;
using pobreTITO_Services;

#pragma warning disable 1998

namespace pobreTITO.Controllers;
[Authorize]
public class ReportController : Controller
{
#pragma warning disable CS8618
    private readonly ILogger<ReportController> _logger;
    private ErrorMessage message = new();
#pragma warning restore CS8618

    public ReportController(ILogger<ReportController> logger)
    {
        _logger = logger;
    }
}