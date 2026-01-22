let svg = document.getElementById('svg');
let callback = null;

export function GameInit (svgRef, _callback) {
    callback = _callback;
    svg=document.getElementById("game-field");
    svg.addEventListener('pointermove', pointerMove);
    svg.addEventListener('pointerdown', pointerDown);
    window.addEventListener('keydown', keyDown);
    window.addEventListener('keyup', keyUp);
}
export function GameDispose(dotNetObject) {
    if (svg) {
        svg.removeEventListener('pointermove', pointerMove);
        svg.removeEventListener('pointerdown', pointerDown);
        svg = null;
    }
    window.removeEventListener('keydown', keyDown);
    window.removeEventListener('keyup', keyUp);
    callback = null;
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
    const p = toSvgCoords(e);
    callback(JSON.stringify({"type": 'pointermove', "x": p.x, "y":p.y}));
}
function pointerDown(e) {
    const p = toSvgCoords(e);
    callback(JSON.stringify({"type": 'pointerdown',"x": p.x, "y":p.y}));
}
function keyDown(e) {
    callback(JSON.stringify({"type":'keydown', "key": e.key}));
}
function keyUp(e) {
    callback(JSON.stringify({"type": 'keyup', "key": e.key}));
}
