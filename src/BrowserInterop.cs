using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
namespace BlazorGame;

[SupportedOSPlatform("browser")]
public static partial class BrowserInterop
{
    //JSImport/JSExport sadly does not make it easy to call instance methods, unlike IJSRuntime, and also
    //limits us to 3 arguments per callback
    //We pass a single handler to the JS side that will get the events as a JSON string
    
    //game.mjs functions
    [JSImport("GameInit", "game")]
    public static partial void GameInit(string svgId, [JSMarshalAs<JSType.Function<JSType.String>>] Action<string> onInput);
    
    //browser functions
    [JSImport("globalThis.requestAnimationFrame")]
    [return: JSMarshalAs<JSType.Number>] 
    public static partial long RequestAnimationFrame([JSMarshalAs<JSType.Function<JSType.Number>>] Action<double> callback);
    [JSImport("globalThis.cancelAnimationFrame")]
    public static partial void CancelAnimationFrame([JSMarshalAs<JSType.Number>] long id);
}