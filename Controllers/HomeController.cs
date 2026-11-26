using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OgnjenDrazic.Web.Models;

namespace OgnjenDrazic.Web.Controllers;

public class HomeController(IOptions<Profile> profileOptions) : Controller
{
    private readonly Profile profile = profileOptions.Value;

    public IActionResult Index()
    {
        var entries = new List<(string Level, string Label, string Value, bool IsQuoted)>
        {
            ("inf", "user: name", profile.Name, true),
            ("inf", "user: role", profile.Role, true),
            ("inf", "user: location", profile.Location, true),
            ("inf", "stack", string.Join(", ", profile.Stack), false),
            ("inf", "interests", string.Join(", ", profile.Interests), false),
            ("wrn", "coffee", "level low, continuing anyway", false),
        };

        var bootLog = new List<LogLine>();
        for (var i = 0; i < entries.Count; i++)
        {
            // Timestamps grow as 1, 4, 9, 16 ... ms so the log looks like a real boot.
            var timestamp = TimeSpan.FromMilliseconds((i + 1) * (i + 1)).ToString(@"hh\:mm\:ss\.fff");
            var entry = entries[i];
            bootLog.Add(new LogLine(timestamp, entry.Level, entry.Label, entry.Value, entry.IsQuoted));
        }

        return View(new HomeViewModel(bootLog, profile.Links));
    }

    // Program.cs re-executes requests that end in an error status (e.g. 404) here,
    // so they get a page in the site's own style.
    [Route("status/{statusCode:int}")]
    public IActionResult Status(int statusCode)
    {
        return View(statusCode);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
