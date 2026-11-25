# AGENTS.md

Guidance for AI coding agents working in this repository.

## Project

Sensor Data Processing Hub: IKT300 (UiA) exam project, portfolio part 1, due **29 Nov 2026, 23:59**. Part 2 is announced 30 Nov 2026 and will extend this code; the planned interfaces cover that, so no extra extensibility is needed.

## Coding rules (read first)

This is an exam project. Its job is to **demonstrate an architecture design and a working solution for it**, not to be a product.

- **Do not over-engineer.** Build what the plan ask for, nothing more. Don't design for imagined customers, companies or future requirements.
- **Readable code first.** Simple, descriptive names (`reading`, `windowSize`, `threshold`, not `r`, `ws`, `thr`). Prefer a plain `foreach` and `if` over clever LINQ chains or pattern tricks.
- **Small, obvious classes and methods.** One responsibility per class; a method should fit on one screen.
- **Comments explain _why_, not _what_.** Add a short comment where a design decision or tactic shows up in the code, so it can be pointed to in the report and at the presentation.
- **No speculative features.** No retry policies, caching, plug-in loading, hot reload, extra protocols or performance tuning unless the brief or the user asks for it.
- **It must run live on stage.** Prefer the boring, reliable option over the impressive one.
- **When in doubt, ask** rather than adding complexity.
- **Prefer** Simplicity before complexity.
