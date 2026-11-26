# AGENTS.md

Guidance for AI coding agents working in this repository.

## Project

Personal website for Ognjen Drazic, served at <https://ognjendrazic.com>. It is an ASP.NET Core MVC app on .NET 10, with the project at the repo root (`OgnjenDrazic.Web.csproj`).

- `appsettings.json`: the `Profile` section holds the site's content (name, role, stack, links). Change text here, not in views.
- `Models/`: `Profile` (bound from config with the options pattern), `LogLine` and `HomeViewModel` (what the home view renders), `ErrorViewModel`.
- `Controllers/HomeController.cs`: `Index` builds the boot log from the profile, `Status` renders 404 and other error statuses, `Error` handles exceptions.
- `Views/Shared/_Layout.cshtml`: page shell, header and footer (the profile is injected with `@inject`).
- `Views/Shared/_LogLine.cshtml`: partial view for one boot log line.
- `Views/Home/`: `Index` (terminal boot log) and `Status` (error status page).
- `wwwroot/css/site.css` and `wwwroot/js/site.js`: styles and the typing animation.
- `Program.cs`: services, options binding and the request pipeline.
- `.github/workflows/deploy.yml`: deploys to GitHub Pages on every push to `main`.

## Hosting

GitHub Pages only serves static files. The deploy workflow runs the app in CI, saves the rendered pages as HTML (`/` as `index.html`, `/status/404` as `404.html`) and publishes those with `wwwroot`. This means:

- Pages are rendered once per deploy, not per request. Anything per-request (forms, logins, live data) won't work on the live site.
- When you add a page, add a `curl` line for it in the "Render pages to static HTML" step of the workflow, or it won't be published.

## Commands

```sh
dotnet build                          # must pass with no warnings
dotnet run                            # run the site locally
dotnet format --verify-no-changes     # check formatting
```

A change is done when:

- `dotnet build` passes with no warnings,
- `dotnet format --verify-no-changes` reports nothing,
- the changed pages have been checked in a browser at desktop and phone widths.

## Coding rules (read first)

This is a small personal site. Its job is to **present who I am and what I do, clearly and reliably**, and to use ASP.NET Core MVC the way it is meant to be used.

- **Lean on the framework.** Where ASP.NET Core already has a feature for something, prefer it over hand-rolled code. Good defaults for this site:
  - content in configuration, bound with `IOptions<T>`
  - fairly thin controllers that hand a view model to a strongly typed view
  - tag helpers, partial views and the layout for shared markup
  - dependency injection for services

  These are defaults, not hard rules. Use judgment, and pick a different approach when it's clearer.
- **New tools are fine when they earn their place.** Packages, a database, APIs or frontend tooling can be added when a feature needs them, not in advance. Mention it when you add one.
- **Do not over-engineer.** Build what is asked for, nothing more. Don't add layers or abstractions for a single use.
- **Readable code first.** Simple, descriptive names (`profile`, `bootLog`, `statusCode`, not `p`, `bl`, `sc`). Follow standard C# conventions: PascalCase for types, methods and properties, camelCase for locals and parameters. Prefer a plain `foreach` and `if` over clever LINQ chains or pattern tricks.
- **Small, obvious classes and methods.** One responsibility per class; a method should fit on one screen.
- **Comments explain _why_, not _what_.** Add a short comment where a choice isn't obvious from the code.
- **Accessible and responsive.** Use semantic HTML, keep text readable on phones, and respect `prefers-reduced-motion` for animations.
- **No speculative features.** Don't add things "for later" that nothing uses yet.
- **Keep it boring and reliable.** It must keep running unattended. Prefer the simple, well-documented option over the clever one.
- **No secrets in the repo.** It is public. Keep keys and connection strings out of `appsettings*.json` and use user secrets or environment variables.
- **When in doubt, ask** rather than adding complexity.

## Git

- Run `git status` before committing and stage only the files that belong to the change. Never stage blindly with `git add -A` or `git add .`: files from other projects have been committed here by mistake before.
- Name each commit after the change that defines it, not a side detail. Put smaller details in the body.
- Work on a branch. Don't push to `main` or force-push without asking.
