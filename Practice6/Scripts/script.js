var url = '@Url.Action("People", "db")';
var url1 = '@Url.Action("People", "cashe")';

console.log("Hello world");

document.getElementById("db").onclick = function () {
    console.log("Hello");
   document.getElementById("div__table").load(url);
}

document.getElementById("cashe").onclick = function () {
    console.log("Good");
}