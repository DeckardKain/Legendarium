
function getMouseXLocation() {
    document.getElementsByClassName("hexagon").onmousemove = e => {
        for (const hexagon of document.getElementsByClassName("hexagon")) {
            const rect = hexagon.getBoundingClientRect(),
                x = e.clientX - rect.left;
            return x;
        };
    }
}
function getMouseYLocation() {
    document.getElementsByClassName("hexagon").onmousemove = e => {
        for (const hexagon of document.getElementsByClassName("hexagon")) {
            const rect = hexagon.getBoundingClientRect(),
                y = e.clientY - rect.top;
            return y;
        };
    }
}
