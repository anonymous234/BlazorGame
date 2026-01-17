let svg = document.getElementById('svg');
let dotNetRef = null;
let rafId = null;
let lastTimestamp = 0;
export function GameInit (dotNetObject) {
    dotNetRef = dotNetObject;
    if (!svg) return;
    svg.style.touchAction = 'none';
    svg.addEventListener('pointermove', pointerMove);
    svg.addEventListener('pointerdown', pointerDown);
    window.addEventListener('keydown', keyDown);
    window.addEventListener('keyup', keyUp);
    lastTimestamp = 0;
    if (rafId) window.cancelAnimationFrame(rafId);
    rafId = window.requestAnimationFrame(frame);
}
export function GameDispose(dotNetObject) {
    if (rafId) {
        window.cancelAnimationFrame(rafId);
        rafId = null;
    }
    if (svg) {
        svg.removeEventListener('pointermove', pointerMove);
        svg.removeEventListener('pointerdown', pointerDown);
        svg = null;
    }
    window.removeEventListener('keydown', keyDown);
    window.removeEventListener('keyup', keyUp);
    dotNetRef = null;
    try {
        dotNetObject.dispose();
    } catch (e) { }
}

function toSvgCoords(evt) {
    try {
        const pt = svg.createSVGPoint();
        pt.x = evt.clientX;
        pt.y = evt.clientY;
        const ctm = svg.getScreenCTM().inverse();
        const sp = pt.matrixTransform(ctm);
        return { x: sp.x, y: sp.y };
    } catch (e) {
        return { x: evt.clientX, y: evt.clientY };
    }
}
function pointerMove(e) {
    if (!dotNetRef) return;
    const p = toSvgCoords(e);
    dotNetRef.invokeMethodAsync('OnInput', 'pointermove', p.x, p.y, '', 0).catch(() => { });
}
function pointerDown(e) {
    if (!dotNetRef) return;
    const p = toSvgCoords(e);
    dotNetRef.invokeMethodAsync('OnInput', 'pointerdown', p.x, p.y, '', e.button).catch(() => { });
}
function keyDown(e) {
    if (!dotNetRef) return;
    dotNetRef.invokeMethodAsync('OnInput', 'keydown', 0, 0, e.key, 0).catch(() => { });
}
function keyUp(e) {
    if (!dotNetRef) return;
    dotNetRef.invokeMethodAsync('OnInput', 'keyup', 0, 0, e.key, 0).catch(() => { });
}

function frame(now) {
    if (!dotNetRef) return;
    if (!lastTimestamp) lastTimestamp = now;
    const delta = now - lastTimestamp;
    lastTimestamp = now;
    dotNetRef.invokeMethodAsync('OnFrame', now, delta).catch(() => { });
    rafId = window.requestAnimationFrame(frame);
}