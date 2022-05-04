//For user name

let user_name = document.getElementById("user_name");

user_name.onblur = function () {
    if (user_name === undefined || user_name.value === "") {
        user_name.style.border = "2px solid #F30404";
        user_name.placeholder = "Incorrectly filled in field";
    } else user_name.style.border = "2px solid #000000";
}


//For phone

let inp = document.getElementById("user_phone");

inp.onblur = function () {
    let regexp = /\+7\([0-9]{3}\)-[0-9]{3}-[0-9]{2}-[0-9]{2}/;
    console.log(inp.value.match(regexp));
    if (inp === undefined || inp.value === "" || inp.value.match(regexp) == null) {
        inp.style.border = "2px solid #F30404";
        inp.placeholder = "Incorrectly filled in field";
    } else inp.style.border = "2px solid #000000";
}

inp.onclick = function () {
    if (inp.value == "" || inp === undefined) {
        inp.value = "+";
        old = 0;
    }
}

let old = 0;

inp.addEventListener('keypress', e => {
    if (!/\d/.test(e.key))
        e.preventDefault();
    var curLen = inp.value.length;

    if (curLen < old) {
        old--;
        return;
    }
    if (curLen == 2)
        inp.value = inp.value + "(";
    if (curLen == 6)
        inp.value = inp.value + ")-";
    if (curLen == 11)
        inp.value = inp.value + "-";
    if (curLen == 14)
        inp.value = inp.value + "-";
    if (curLen > 16)
        inp.value = inp.value.substring(0, inp.value.length - 1);

    old++;
});