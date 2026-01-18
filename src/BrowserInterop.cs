using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

[SupportedOSPlatform("browser")]
public static partial class BrowserInterop
{
    //game.mjs functions
    
    
    //browser functions
    [JSImport("globalThis.requestAnimationFrame")]
    [return: JSMarshalAs<JSType.Number>] 
    public static partial long RequestAnimationFrame([JSMarshalAs<JSType.Function<JSType.Number>>] Action<double> callback);
    [JSImport("globalThis.cancelAnimationFrame")]
    public static partial void CancelAnimationFrame([JSMarshalAs<JSType.Number>] long id);
}
