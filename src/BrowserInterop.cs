using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace BlazorGame;

/// <summary>
/// Handles interop with game.mjs and browser events
/// </summary>
// This design assumes only one instance of the game exists. Otherwise you'd need to register a DotNetObject with the JS module
[SupportedOSPlatform("browser")]
public static partial class BrowserInterop
{
    //game.mjs events
    [JSImport("Init", "game")]
    public static partial Task GameInit(string svgId, string assemblyName);

    [JSImport("Dispose", "game")]
    public static partial void Dispose();
    
    public readonly struct DomEventArgs(string eventName, string strParam, double x, double y)
    {
        public string EventName => eventName;
        public string KeyName => strParam;
        public double X => x;
        public double Y => y;
    }

    /// <summary>
    /// Raised on receiving event from game.mjs
    /// </summary>
    public static event EventHandler<DomEventArgs>? SvgDomEventReceived;
    [JSExport]
    private static void OnDomEventJs(string eventName, string strParam, double x, double y) => 
        SvgDomEventReceived?.Invoke(null, new DomEventArgs(eventName, strParam, x, y));
    
    
    //native browser functions
    [JSImport("globalThis.requestAnimationFrame")]
    [return: JSMarshalAs<JSType.Number>] 
    public static partial long RequestAnimationFrame([JSMarshalAs<JSType.Function<JSType.Number>>] Action<double> callback);
    [JSImport("globalThis.cancelAnimationFrame")]
    public static partial void CancelAnimationFrame([JSMarshalAs<JSType.Number>] long id);
}