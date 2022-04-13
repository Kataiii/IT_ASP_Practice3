console.log("Hello world");
document.getElementById("button_add").onclick = function () {
    if (document.getElementById("panel_add").style.display == "block") {
        document.getElementById("panel_add").style.display = "none";
    } else {
        document.getElementById("panel_add").style.display = "block";
    }
}

document.getElementById("button_update").onclick = function () {
    if (document.getElementById("panel_update").style.display == "block") {
        document.getElementById("panel_update").style.display = "none";
    } else {
        document.getElementById("panel_update").style.display = "block";
    }
}