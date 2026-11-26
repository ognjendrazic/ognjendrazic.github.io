namespace OgnjenDrazic.Web.Models;

// One line of the boot log on the home page, e.g.
// [00:00:00.004] <inf> user: role = "3rd-year Computer Engineering @ University of Agder"
public record LogLine(string Timestamp, string Level, string Label, string Value, bool IsQuoted);
