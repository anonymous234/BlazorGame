## About
This Blazor project can be used as a template to create SVG-based games.
The idea is to reuse as much existing technology as possible and take advantage of Blazor's component model, and minimize 
the amount of JS code.
This should allow each component to handle its own events, rendering and logic. You could even embed HTML in the SVG.

## To do
- JSImport:
  - Why can't I use ElementReference, DotNetObjectReference with JsImport?
  - Why can't I call instance methods? Or callbacks with more than 3 parameters?
  - https://stackoverflow.com/questions/77707229/pass-net-objects-to-js-wasm

- https://rogueplanetoid.com/articles/blazor-games/
- https://blazorgames.net
- https://mstack.nl/blogs/20210630-blazor-game-development-1-2/
- https://github.com/SteveDunn/PacManBlazor
- https://github.com/carlfranklin/BlazorCanvas
- https://www.davidguida.net/blazor-gamedev-part-2-canvas-initialization/
- https://github.com/aventius-software/BlazorGE/blob/master/BlazorGE.Core/wwwroot/playFieldInterop.js
- https://github.com/aventius-software/BlazorGE/blob/master/BlazorGE.Core/Components/PlayField.razor.cs

- Handle aspect ratio changes (preserveAspectRatio="xMidYMid meet")
- Clean game.mjs: remove toSvgCoords, use Blazor event handlers
- Menu? Scrolling worlds (e.g. Super Mario Bros)?

## Sample games
- 2048
- RPG game (to test menus)
  - Deltarune clone
- Tetris
- Mario (single-screen)
- Angry Birds (Box2D.NET)
- https://blazorgames.net/

## Future
- Maybe rename it BlazorSVGGame
- Make sure publishing (GitHub pages) is easy
  - https://docs.github.com/en/codespaces/setting-up-your-project-for-codespaces/setting-up-your-repository/setting-up-a-template-repository-for-github-codespaces
  - https://resources.github.com/learn/pathways/automation/advanced/building-your-first-custom-github-action/