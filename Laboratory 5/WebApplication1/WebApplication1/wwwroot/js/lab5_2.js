
var canvasArray = document.getElementsByClassName("drawingX");
var ctxArray = [];

for (let i = 0; i < canvasArray.length; i++) {
    ctxArray[i] = canvasArray[i].getContext("2d");
}

// var canvas = canvasArray[0];
// var ctx = ctxArray[0];

for (let i = 0; i < canvasArray.length; i++) {
    canvasArray[i].addEventListener('mousemove', (event) => {
        const ctx = canvasArray[i].getContext("2d");

        mousePos = { x: event.clientX, y: event.clientY };
        y = mousePos.y;
        x = mousePos.x;

        ctx.clearRect(0, 0, canvasArray[i].width, canvasArray[i].height);

        ctx.beginPath();

        canvasRect = canvasArray[i].getBoundingClientRect();
        canvasLeft = canvasRect.left;
        canvasTop = canvasRect.top;

        ctx.moveTo(0, y - canvasTop);
        ctx.lineTo(x - canvasLeft, y - canvasTop);
        ctx.stroke();

        ctx.moveTo(x - canvasLeft, 0);
        ctx.lineTo(x - canvasLeft, y - canvasTop);
        ctx.stroke();

        ctx.moveTo(canvasArray[i].width, y - canvasTop);
        ctx.lineTo(x - canvasLeft, y - canvasTop);
        ctx.stroke();

        ctx.moveTo(x - canvasLeft, canvasArray[i].height);
        ctx.lineTo(x - canvasLeft, y - canvasTop);
        ctx.stroke();

        ctx.closePath();
    })

    canvasArray[i].addEventListener('mouseout', (event) => {
        const ctx = canvasArray[i].getContext("2d");
        ctx.clearRect(0, 0, canvasArray[i].width, canvasArray[i].height);
    })

};

// window.addEventListener('mousemove', (event) => {
//     mousePos = { x: event.clientX, y: event.clientY };
//     clearCanvas();
//     const canvasCurrent = event.target.getElementsByClassName("drawingX")
//     writeLines(mousePos.x, mousePos.y, can, canvasCurrent);
// });


function writeLines(x, y, canvasCurrent) {

    ctx = canvasCurrent.getContext("2d");
    canvas = canvasCurrent;
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    ctx.beginPath();
    canvasRect = canvas.getBoundingClientRect();
    canvasLeft = canvasRect.left;
    canvasTop = canvasRect.top;

    ctx.moveTo(0, y - canvasTop);
    ctx.lineTo(x - canvasLeft, y - canvasTop);
    ctx.stroke();

    ctx.moveTo(x - canvasLeft, 0);
    ctx.lineTo(x - canvasLeft, y - canvasTop);
    ctx.stroke();

    ctx.moveTo(canvas.width, y - canvasTop);
    ctx.lineTo(x - canvasLeft, y - canvasTop);
    ctx.stroke();

    ctx.moveTo(x - canvasLeft, canvas.height);
    ctx.lineTo(x - canvasLeft, y - canvasTop);
    ctx.stroke();

    ctx.closePath();

}

// function checkCurrentCanvas(x, y) {
//     for (let i = 0; i < canvasArray.length; i++) {
//         let canvasCurrent = canvasArray[i];
//         canvasRect = canvasCurrent.getBoundingClientRect();
//         canvasLeft = canvasRect.left;
//         canvasTop = canvasRect.top;
//         if (x >= canvasLeft && x <= canvasLeft + canvasCurrent.width && y >= canvasTop && y <= canvasTop + canvasCurrent.height) {
//             ctx = ctxArray[i];
//             canvas = canvasArray[i];
//             return true;
//         }
//     }
//     return false;
// }