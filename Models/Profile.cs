namespace OgnjenDrazic.Web.Models;

// Bound from the "Profile" section of appsettings.json (options pattern),
// so the site's text can be changed without touching code.
public class Profile
{
    public const string SectionName = "Profile";

    public string Name { get; set; } = "";
    public string Role { get; set; } = "";
    public string Location { get; set; } = "";
    public string Description { get; set; } = "";
    public List<string> Stack { get; set; } = [];
    public List<string> Interests { get; set; } = [];
    public List<ProfileLink> Links { get; set; } = [];
    public string SourceUrl { get; set; } = "";
}

public class ProfileLink
{
    public string Label { get; set; } = "";
    public string Url { get; set; } = "";

    // Shown in the terminal without the scheme, e.g. "github.com/ognjendrazic".
    public string DisplayUrl => Url.Replace("https://", "").TrimEnd('/');
}
