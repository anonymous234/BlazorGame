let svg = null;
let callback = null;

export async function Init(svgId, assemblyName) {
    //This is a bit fragile, but unavoidable
    const { getAssemblyExports } = await globalThis.getDotnetRuntime(0);
    const exports = await getAssemblyExports(assemblyName); //eg. "BlazorGame.dll"
    callback = exports.BlazorGame.BrowserInterop.OnDomEventJs;
    if (!callback) throw 'Method OnDomEventJs not found in assembly ' + assemblyName;

    svg = document.getElementById(svgId);
    if (!svg) throw 'Invalid SVG: ' + svgId;

    svg.addEventListener('pointerdown', pointerDown);

    // pointermove and pointerup on the window, so dragging outside the SVG keeps working.
    window.addEventListener('pointermove', pointerMove);
    window.addEventListener('pointerup',   pointerUp);
    window.addEventListener('keydown', keyDown);
    window.addEventListener('keyup',   keyUp);
}

export function Dispose() {
    //Might be called multiple times
    if (!svg && !callback) return;
    svg.removeEventListener('pointerdown', pointerDown);
    window.removeEventListener('pointermove', pointerMove);
    window.removeEventListener('pointerup',   pointerUp);
    window.removeEventListener('keydown', keyDown);
    window.removeEventListener('keyup',   keyUp);
    svg = null;
    callback = null;
}

function toSvgCoords(evt) {
    try {
        const pt = svg.createSVGPoint();
        pt.x = evt.clientX;
        pt.y = evt.clientY;
        const ctm = svg.getScreenCTM().inverse();
        const sp = pt.matrixTransform(ctm);
        return { x: sp.x, y: sp.y };
    } catch {
        return { x: evt.clientX, y: evt.clientY };
    }
}
function pointerDown(e) {
    const p = toSvgCoords(e);
    callback('pointerdown', null, p.x, p.y);
}
function pointerMove(e) {
    if (!svg) return;
    const p = toSvgCoords(e);
    callback('pointermove', null, p.x, p.y);
}
function pointerUp(e) {
    if (!svg) return;
    const p = toSvgCoords(e);
    callback('pointerup', null, p.x, p.y);
}
function keyDown(e) { callback('keydown', e.key, 0, 0); }
function keyUp(e)   { callback('keyup',   e.key, 0, 0); }