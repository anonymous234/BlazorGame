BlazorGame is an experimental template to build games using Blazor WASM and SVG.
The idea was to reuse as much existing technology as possible and take advantage of Blazor's component model.

Why use &lt;canvas> and bitmaps like a cave person when you can use reactive vector graphics and components like it's the future?
You could even embed HTML in the SVG and use that for the user interface.

Features:
- A SVG to draw things on
- High performance interop to receive keyboard and mouse events
- A reusable RequestAnimationFrame hook to handle animation
- Nothing else

Well, if you want to build a prototype in C#, it's pretty handy.

## Usage
- The viewBox is defined as 1200x600, which should be treated as the main game area. However, more area might be visible
than that in some screen sizes.
- Due to Razor syntax, to add a &lt;text> element it's necessary to use "@:&lt;text>".
 
