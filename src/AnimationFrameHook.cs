using System.Runtime.Versioning;

namespace BlazorGame;
[SupportedOSPlatform("browser")]
public static class AnimationFrameHook
{
    //Important: not currently thread-safe since Blazor WASM is single-threaded. Add locks if it's necessary in the future.
    //static readonly Lock Locker = new();
    static EventHandler<BrowserAnimationFrameEventArgs>? TheEvent;
    static long? ActiveRequestId;

    public class BrowserAnimationFrameEventArgs : EventArgs
    {
        /// <summary>
        /// Timestamp in milliseconds since the page was loaded
        /// </summary>
        public double Timestamp { get; internal init; }
    }
    public static event EventHandler<BrowserAnimationFrameEventArgs> BrowserAnimationFrame
    {
        add
        {
            bool start = TheEvent == null;
            TheEvent += value;
            if(start) ActiveRequestId = BrowserInterop.RequestAnimationFrame(BrowserCallback);
        }
        remove
        {
            TheEvent -= value;
            if (TheEvent == null) StopListening();
        }
    }

    static void StopListening()
    {
        if(ActiveRequestId != null)
        {
            BrowserInterop.CancelAnimationFrame(ActiveRequestId.Value);
            ActiveRequestId = null;
        }
    }
    static void BrowserCallback(double timestamp)
    {
        ActiveRequestId = null;
        TheEvent?.Invoke(null, new BrowserAnimationFrameEventArgs { Timestamp = timestamp });
        ActiveRequestId = BrowserInterop.RequestAnimationFrame(BrowserCallback);
    }
}