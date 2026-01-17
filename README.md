## To do
- Center the game
- Why InvokeAsync(StateHasChanged)?
- Call module.DisposeAsync() ??
  https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/call-javascript-from-dotnet?view=aspnetcore-10.0#javascript-isolation-in-javascript-modules
- Remove svgRef and let game.mjs handle it?


- https://mstack.nl/blogs/20210630-blazor-game-development-1-2/
- https://github.com/SteveDunn/PacManBlazor
- https://github.com/carlfranklin/BlazorCanvas
- https://www.davidguida.net/blazor-gamedev-part-2-canvas-initialization/
- https://github.com/aventius-software/BlazorGE/blob/master/BlazorGE.Core/wwwroot/playFieldInterop.js
- https://github.com/aventius-software/BlazorGE/blob/master/BlazorGE.Core/Components/PlayField.razor.cs

### JS bits
Design: minimize JS code but not if it requires unreasonable effort.

Learn and migrate to https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/import-export-interop?view=aspnetcore-10.0#call-net-from-javascript

This will lock us into WASM mode, but it's probably better.

- Remove as much JS as possible.
- Leave page-wide keyboard, requestAnimationFrame events in Javascript. Or can I do those with JSImport?
- Others (e.g. Sound?)

## Structure

- Can I put game logic in a separate project? Should I?
    Like
    <svg>
    <someOtherAssembly.TheActualGame />
    </svg>
Or it could be an interface?

- Merge Game.razor, App.razor


## About

It's a Blazor template

The game will be SVG-based, not canvas, with as little JavaScript as possible.

Checklist:
- Merge Game/Game2
- Git
- window.requestAnimationFrame()
- Add 2D movement
- Add sound
- Try making a menu
- Scrolling world (e.g. Super Mario Bros): how?

## Sample games
- Tetris
- Mario (single-screen)
- Angry Birds (Box2D.NET)

## Future
- Make sure publishing (GitHub pages) is easy
- Test with Blazor Native/Server

