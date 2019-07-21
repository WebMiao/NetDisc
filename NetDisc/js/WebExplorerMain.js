//the main file communicate with page interface

//***********************//
//** initialize a tree **//
//***********************//

//create a tree object
var nd = new TreeNode();

//where the tree oject is deploy
//specify a div tag/container
nd.container = $("tree"); //place the tree to a <div> with ID named "tree"

nd.text = "Net Disc";

//show the tree 
nd.Show();

//set the node created as current node
currentNode = nd;

currentNode.Refresh();

/*****************************/
/** List the tree structure **/
/*****************************/


/*****************************/
/** Load the dialog **/
/*****************************/
var dialog = new Dialog();
dialog.ImgZIndex = 110;
dialog.DialogZIndex = 111; //far away

/*****************************/
/**** Download Operation *****/
/*****************************/
clickFile = function (fname) { //supply the function realization part in tree.js
    window.onbeforeunload = function () { }
    window.location = defaultURL + "?action=DOWNLOAD&value1=" + encodeURIComponent(currentNode.path + fname);
    alter(window.location);
    window.onbeforeunload = function () {
        return "cannot save the current state, please cannel!";
    };
}

/*****************************/
/****** Online Editing *******/
/*****************************/
var fileEditor = new Dialog();
fileEditor.Content = "<div id='editorDiv>" + //deine the empty rich editor
    "<input id = 'switchEditor' type='button' value='Switch Editor'/>" +
    "<br />" +
    "<textarea id='FileContentTextArea' cols='80' rows='30' style='width:600px; height:400px'></textarea>" +
    "</div >";
fileEditor.width = 600; //set the width

var oCKeditor; //define a rich editor object
var oEditor;  //define a rich editor instance
var isRichEditor = false; // the current state of editor
var currentContent = ""; //the current content inside the editor
var textareaEditor = null; //define a text editor
var switchButton = null; //switch between Rich editor and text editor
var list = null; //the file be specify
var cutCopyOperation = null; //define current opertaions
var cutCopyFiles = null; //define thefile be operated
var currentEditFile = null; //the file need to be edited

function switchEditor() {
    getEditorContent(); //Firstly, get the content
    if (isRichEditor) {
        isRichEditor = false; //already get the content
        // create a new file

    }
}

//get the content of the editor
function getEditorContent() {
    if (ifRichEditor) {
        currentContent = oEditor.GetXHTML(true); //call the function defined in CKEditor
    } else {
        currentContent = textareaEditor.value;
    }
}

// create a new file
function newFile() {
    idRichEditor = false;
    fileEditor.Text = "Create New File";
    fileEditor.Show(2);

    //find the elements of Editor
    textareaEditor = $("FileContentTextArea"); //find the <div>
    switchButton = $("switchEditor");

    textareaEditor.value = currentContent;
    switchButton.onclick = switchEditor;
    fileEditor.Close = closeConfirm;
    fileEditor.OK = function () {
        dialog.Content = "<span>Please the File Name: </span>" +
            "<input id = 'inputFile' type='textbox' style='width:100px'/>";
        dialog.Show(2);
        dialog.OK = saveNewFile; //save new file function
    }
}

//save the new file 
function saveNewFile() {
    var result = saveFile("NEWFILE", $(inputFile).value);
    dialog.Text = "Note";
    if (result == "OK") {
        dialog.Content = "The file is created successfully";
        currentNode.Refresh();
        fileEditor.Hide();
    }
}

//save file [saveFile = save the editing file]
function saveFile(action, fileName) {
    getEditorContent();
    var url = defaultURL + "?action=" + action + "&value1=" + encodeURIComponent(currentNode.path + fileName);
    return executeHttpRequest("POST", url, "content=" + encodeURIComponent(currentContent));
}

//Dialog to confirm to exit
function closeConfirm() {
    dialog.Text = "Note";
    dialog.Content = "<span style='color:red;'>Text is changed, do you confirm to exit?</span>";
    dialog.Show();
    dialog.OK = function () {
        dialog.Close();
        fileEditor.Hide();
        currentContent = null; //clear
    }
}

//edit file
editFile = function (fname) {
    isRichEditor = false;
    currentEditFile = fname;
    fileEditor.Text = "Edit File:" + fname;
    fileEditor.Show(3);

    //find the elements of Editor
    textareaEditor = $("FileContentTextArea"); //find the <div>
    switchButton = $("switchEditor");

    //read the file on the server
    textareaEditor.value = loadFileContent(fname); //get the file need to be edited

    switchButton.onclick = switchEditor;
    fileEditor.Close = closeConfirm;//indirectly close
    fileEditor.OK = function () {
        var result = saveFile("SAVAEDITFILE", fname);
        dialog.Text = "Note";
        if (result == "OK") {
            dialog.Content = "The file is saved successfully";
            currentNode.Refresh();
            fileEditor.Hide();
        } else {
            dialog.Content = "Fail to save file";
        }
        dialog.OK = dialog.Close;
        dialog.Show(1);
    }
    fileEditor.Retry = function () {
        if (isRichEditor) {
            oEditor.SetData(loadFileContent(fname));

        } else {
            textareaEditor.value = loadFileContent(fname);
        }
    }
}

//read the file on the server
loadFileContent = function (fname) {
    var url = defaultURL + "?action=GETEDITFILE&value1=" + encodeURIComponent(currentNode.path + fname);
    var content = executeHttpRequest("GET", url, null);

    if (content == "ERROR") {
        dialog.Text = "Error!";
        dialog.Content = "Fail to read file";
        dialog.Show(1);
        content = "";
        dialog.OK = dialog.Close;
    }
    return content;
}