## About
BlazorGame is an experimental template to build games using Blazor WASM and SVG.
The philosophy is to reuse as much existing technology as possible and take advantage of Blazor's component model, and minimize
everything else.
This should allow each component to handle its own events, rendering and logic. You could even embed HTML in the SVG.

## Design rules
The App.razor file contains a SVG element and the event handlers.
Keep things as simple as possible.
User components will be inside the SVG element, and output only SVG elements (<g>, <rect> or <text>...). 
All the game logic will be in those components.

- Javascript goes in game.mjs. Only the bare minimum to redirect events to .net when necessary.
- HTML goes in index.html

Note: due to Razor syntax, to add a <text> element it's necessary to use "@:<text>".

## Usage
The viewBox is defined as 1200x600, which should be treated as the main game area. However, more area might be visible
than that in some screen sizes.