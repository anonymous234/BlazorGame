## To do
- Why InvokeAsync(StateHasChanged)?
- Call module.DisposeAsync() ??
  https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/call-javascript-from-dotnet?view=aspnetcore-10.0#javascript-isolation-in-javascript-modules
- https://learn.microsoft.com/en-us/aspnet/core/blazor/performance/javascript-interoperability?view=aspnetcore-10.0#consider-the-use-of-synchronous-calls


- https://mstack.nl/blogs/20210630-blazor-game-development-1-2/
- https://github.com/SteveDunn/PacManBlazor
- https://github.com/carlfranklin/BlazorCanvas
- https://www.davidguida.net/blazor-gamedev-part-2-canvas-initialization/
- https://github.com/aventius-software/BlazorGE/blob/master/BlazorGE.Core/wwwroot/playFieldInterop.js
- https://github.com/aventius-software/BlazorGE/blob/master/BlazorGE.Core/Components/PlayField.razor.cs

- Can I put game logic in a separate project? Should I?
  Like
  <svg>
  <someOtherAssembly.TheActualGame />
  </svg>
  Or it could be an interface?

- Handle aspect ratio changes (preserveAspectRatio="xMidYMid meet")
- Clean game.mjs: can I remove toSvgCoords?
### JS bits
Design: minimize JS code but not if it requires unreasonable effort.

Learn and migrate to https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/import-export-interop?view=aspnetcore-10.0#call-net-from-javascript

This will lock us into WASM mode, but it's probably better.

- Remove as much JS as possible.
- Leave page-wide keyboard, requestAnimationFrame events in Javascript. Or can I do those with JSImport?
- Others (e.g. Sound?)


## About

It's a Blazor template

The game will be SVG-based, not canvas, with as little JavaScript as possible.

Checklist:
- window.requestAnimationFrame()
- Add sound
- Try making a menu
- Scrolling world (e.g. Super Mario Bros): how?

## Sample games
- Tetris
- Mario (single-screen)
- Angry Birds (Box2D.NET)

## Future
- Make sure publishing (GitHub pages) is easy
  - https://docs.github.com/en/codespaces/setting-up-your-project-for-codespaces/setting-up-your-repository/setting-up-a-template-repository-for-github-codespaces
  - https://resources.github.com/learn/pathways/automation/advanced/building-your-first-custom-github-action/

