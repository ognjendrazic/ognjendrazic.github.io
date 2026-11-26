namespace OgnjenDrazic.Web.Models;

public record HomeViewModel(IReadOnlyList<LogLine> BootLog, IReadOnlyList<ProfileLink> Links);
