//organize other js
//类似于jquery -> 返回jQuery元素
//自己写的筛选器，返回html元素

//Find the html tag base on ID
//example: var btn = $("btn_ok");
function $(divID) {
    return document.getElementById(divID);
}

//create the <img> tag
var createImg = function () {
    return document.createElement("img");
}

//create button tag 
var createBtn = function () {
    var btn = document.createElement("input");
    btn.type = "button"; //change the type of <input>
    return btn;
}

//create <div> tag
var createDiv = function () {
    return document.createElement("div");
}

//create <span> tag to show the text on the webpage
var createSpan = function () {
    return document.createElement("span");
}

//create character filter by using regular expression
String.prototype.trim = function () {
    return this.replace("",""); //待定
}