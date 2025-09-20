/*
 *OK I gotta read some shit
 * https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/call-dotnet-from-javascript?view=aspnetcore-10.0#javascript-jsimportjsexport-interop
 * https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/import-export-interop?view=aspnetcore-10.0
 * 
 */
using Microsoft.JSInterop;
namespace BlazorGame;
#if false
public class AnimationFrameHook
{
    private IJSRuntime JsRuntime;
    public async Task RegisterEvent(IJSRuntime JsRuntime)
    {
        ArgumentNullException.ThrowIfNull(JsRuntime);
        this.JsRuntime = JsRuntime;
        //DotNetObjectReference?
        await JsRuntime.InvokeAsync<long>("requestAnimationFrame", (object) HandleAnimationFrame);
    }
    
    //https://developer.mozilla.org/en-US/docs/Web/API/Window/cancelAnimationFrame
    
    
    [JSInvokable]
    public void HandleAnimationFrame(long timestamp)
    {
        //Do stuff
        
        //Register next frame
        JsRuntime.InvokeAsync<long>("requestAnimationFrame", HandleAnimationFrame);
    }

    
    
    public static event EventHandler BrowserPainting;
    //private static IJSRuntime JsRuntime;
    /*
    delegate void RequestAnimationFrameCallback(long timestamp);
    //Maybe this should be an Event?
    //Or a CancellationToken
    public RequestAnimationFrameHook(IJSRuntime JsRuntime)
    {
        JsRuntime.InvokeAsync<long>("requestAnimationFrame", DotNetObjectReference.Create(this));
    }
    [JSInvokable]
    public void OnRequestAnimationFrame(long timestamp)
    {
        BrowserPainting?.Invoke(this, EventArgs.Empty);
    }
    private void ReleaseUnmanagedResources()
    {
        // TODO release unmanaged resources here
        
    }

    public void Dispose()
    {
        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }

    ~RequestAnimationFrameHook()
    {
        ReleaseUnmanagedResources();
    }*/
}
#endif