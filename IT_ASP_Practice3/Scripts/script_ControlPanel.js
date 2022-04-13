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

document.getElementById("button_delete").onclick = function () {
    if (document.getElementById("panel_delete").style.display == "block") {
        document.getElementById("panel_delete").style.display = "none";
    } else {
        document.getElementById("panel_delete").style.display = "block";
    }
}

document.getElementById("button_add_product").onclick = function () {
    if (document.getElementById("panel_add_product").style.display == "block") {
        document.getElementById("panel_add_product").style.display = "none";
    } else {
        document.getElementById("panel_add_product").style.display = "block";
    }
}