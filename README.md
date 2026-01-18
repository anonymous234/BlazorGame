## To do
- Well, I can't debug...
- Call module.DisposeAsync() ??
  https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/call-javascript-from-dotnet?view=aspnetcore-10.0#javascript-isolation-in-javascript-modules 
- https://learn.microsoft.com/en-us/aspnet/core/blazor/performance/javascript-interoperability?view=aspnetcore-10.0#consider-the-use-of-synchronous-calls

- https://rogueplanetoid.com/articles/blazor-games/
- https://blazorgames.net
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
- 2048
- RPG game (to test menus)
- Tetris
- Mario (single-screen)
- Angry Birds (Box2D.NET)
- https://blazorgames.net/

## Future
- Maybe rename it BlazorSVGGame
- Make sure publishing (GitHub pages) is easy
  - https://docs.github.com/en/codespaces/setting-up-your-project-for-codespaces/setting-up-your-repository/setting-up-a-template-repository-for-github-codespaces
  - https://resources.github.com/learn/pathways/automation/advanced/building-your-first-custom-github-action/

## FAQ
Q: Why not just use <canvas>?
A: Because there's no point to canvas. SVG lets the browser handle and render the elements. With canvas, you might as well write a local application.  
The point was to reuse as much existing technology as possible.