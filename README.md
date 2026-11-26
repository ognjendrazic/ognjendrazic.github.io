# ognjendrazic.com

Source for my personal site, as an ASP.NET Core MVC app (.NET 10).

```sh
dotnet run
```

| Path | What it is |
| --- | --- |
| `appsettings.json` | the site's content, in the `Profile` section |
| `Controllers/HomeController.cs` | home page, status pages and error handling |
| `Models/` | `Profile` (bound from config), view models |
| `Views/Shared/_Layout.cshtml` | header, footer and page shell |
| `Views/Home/Index.cshtml` | the terminal boot log on the home page |
| `wwwroot/` | styles and the typing animation |
