console.log("Hello world");

//Customers
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

//Products
document.getElementById("button_add_product").onclick = function () {
    if (document.getElementById("panel_add_product").style.display == "block") {
        document.getElementById("panel_add_product").style.display = "none";
    } else {
        document.getElementById("panel_add_product").style.display = "block";
    }
}

document.getElementById("button_delete_product").onclick = function () {
    if (document.getElementById("panel_delete_product").style.display == "block") {
        document.getElementById("panel_delete_product").style.display = "none";
    } else {
        document.getElementById("panel_delete_product").style.display = "block";
    }
}

document.getElementById("button_update_product").onclick = function () {
    if (document.getElementById("panel_update_product").style.display == "block") {
        document.getElementById("panel_update_product").style.display = "none";
    } else {
        document.getElementById("panel_update_product").style.display = "block";
    }
}

//Orders
document.getElementById("button_add_order").onclick = function () {
    if (document.getElementById("panel_add_order").style.display == "block") {
        document.getElementById("panel_add_order").style.display = "none";
    } else {
        document.getElementById("panel_add_order").style.display = "block";
    }
}

document.getElementById("button_update_order").onclick = function () {
    if (document.getElementById("panel_update_order").style.display == "block") {
        document.getElementById("panel_update_order").style.display = "none";
    } else {
        document.getElementById("panel_update_order").style.display = "block";
    }
}

document.getElementById("button_delete_order").onclick = function () {
    if (document.getElementById("panel_delete_order").style.display == "block") {
        document.getElementById("panel_delete_order").style.display = "none";
    } else {
        document.getElementById("panel_delete_order").style.display = "block";
    }
}