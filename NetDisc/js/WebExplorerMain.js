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
fileEditor.Content = "<div id='editorDiv'>" + //deine the empty rich editor
    "<input id ='switchEditor' type='button' value='Switch Editor'/>" +
    "<br />"+
    "<textarea id='FileContentTextArea' name='FileContentTextArea' cols='80' rows='30' style='width:600px; height:400px'></textarea>" +
    "</div >";
fileEditor.width = 1000; //set the width

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
var tempHTMLContent = null;

function switchEditor() {
    getEditorContent(); //Firstly, get the content
    if (isRichEditor) {
        isRichEditor = false; //already get the content
        // create a new file
        newFile();
    } else {
        isRichEditor = true;
        //create editor
        oCKeditor = CKEDITOR.replace('FileContentTextArea');
    }
}

//get the content of the editor
function getEditorContent() {
    if (isRichEditor) {
        currentContent = CKEDITOR.instances.FileContentTextArea.getData().substring(3, CKEDITOR.instances.FileContentTextArea.getData().length-5);
            //CKEDITOR.instances.FileContentTextArea.getData().value;
        //$('FileContentTextArea').value;
            //.getData();
            //oEditor.GetXHTML(true); //call the function defined in CKEditor
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

//back to the last layer
function gotoParentDirctory() {
    if (currentNode != null) {
        currentNode.gotoParentNote();
    }
}

//go to the root dirctory
function goRoot() {
    currentNode = nd;
    currentNode.Refresh();
}

//refresh from the current node
function refresh() {
    if (currentNode != null) {
        currentNode.Refresh();
    }
}

//select all the directory
function selectAll() {
    //get all the tag[button/label/checkbox/radiobutton...] in that page 
    var checkBoxes = $("fileList").getElementsByTagName("input");

    for (var i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i].type == "checkbox") {
            checkBoxes[i].checked = $("checkAll").checked; //depend on the checkAll button
        }
    }
}

//New directory
function newDirectory() {
    dialog.Content = "<div><span>Please input the name of new directory: </span> " +
        "<input id = 'dirName' type='textbox' style='width:100px;' /></div>";
    dialog.Text = "New Directory"; //This is the title of dialog
    dialog.Show();

    var dir = $("dirName");
    dir.focus();

    dialog.OK = function () {
        //if the format is wrong
        if (!(/^[[\u4e00-\u9fa5_a-zA-Z0-9]+$/.test(dir.value))) {
            dialog.Content = "<span style='color:red'>Directory Name is wrong!</span>";

            dialog.OK = function () {
                newDirectory();
            }

            dialog.Show(1);
            return;
        } else {
            //the url for the asychronize call by server
            var url = defaultURL + "?action=NEWDIR&value1=" + encodeURIComponent(currentNode.path);
            var result = executeHttpRequest("GET", url, null);

            if (result == "OK") {
                currentNode.Refresh();
                dialog.Content = "New Directory Successfully";
                dialog.Show(1);
                dialog.OK = dialog.Close;
            } else {
                dialog.Content = "<span tyle='color:red'>Fail to create new Directory, Please try again!</span>";
                dialog.Show();

                dialog.OK = function () {
                    newDirectory();
                }
            }
        }

    }
}

// check the file name is valid
function checkFileName() {
    return (/^[\w\u4e00-\u9fa5-\.]+\.[a-zA-Z0-9]{1.8}$/.test($("inputFile").value));
}

//get the selected files which is checked
function getSelectedFile() {
    list = [];
    var checkBoxes = $("fileList").getElementsByTagName("input");

    for (var i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i].type == "checkbox") {
            if (checkBoxes[i].checked) {
                list.push(currentNode.path + checkBoxes[i].title);
            }
        }
    }
}

//delete function
function del() {
    getSelectedFile();
    dialog.Text = "Delete File(s)";

    if (list.length <= 0) {
        dialog.Content = "Please select the files want to be deleted first";

        dialog.OK = dialog.Close;

        dialog.Show(1);
        return;
    } else {
        dialog.Content = "These files can not be recovered after deleting, confirm to continue?";
        dialog.Show();

        dialog.OK = function () {
            var url = defaultURL + "?action=DELETE&value1=" + encodeURIComponent(list.join("|"));
            var result = executeHttpRequest("GET", url, null);

            if (result == "OK") {
                currentNode.Refresh();

                dialog.Content = "Delete Successfully";
                dialog.OK = dialog.Close;
                dialog.Show(1);
            } else {
                dialog.Content = "<span tyle='color:red'> Failed to delete, please try again!</span>";
                dialog.Show(1);
                currentNode.Refresh();
                dialog.OK = dialog.Close;
            }
        }
    }
}

function cut() {
    getSelectedFile();
    dialog.Text = "Cut Operation";

    if (list.length < 1) {
        dialog.Content = "Please select the files want to be cut first";
    } else {
        dialog.Content = "Already copy the following folders and/or files: <br />" +
            "<div style='text-align:left;'>" + list.join("<br />") + "</div>";
        cutCopyOperation = "CUT";
        cutCopyFiles = list;
    }

    dialog.Show(1);
    dialog.OK = dialog.Close;
}

function copy() {
    getSelectedFile();
    dialog.Text = "Copy Operation";

    if (list.length < 1) {
        dialog.Content = "Please select the files want to be copy first";
    } else {
        dialog.Content = "Already copy the following folders and/or files: <br />" +
            "<div style='text-align:left;'>" + list.join("<br />") + "</div>";
        cutCopyOperation = "COPY ";
        cutCopyFiles = list;
    }

    dialog.Show(1);
    dialog.OK = dialog.Close;
}

function paste() {
    dialog.Text = "Paste";

    if (cutCopyOperation != "CUT" && cutCopyOperation != "COPY" || cutCopyFiles.length < 1) {
        dialog.Content = "clipboard has no folders and files";
        dialog.OK = dialog.Close;
        dialog.Show(1);
        return;
    }

    dialog.Content = "Confrim to paste the following files at " + currentNode.path + "？<br />" +
        "<div style='text-align:left';>" + cutCopyFiles.join("<br />")+"</div>";
    dialog.Show();

    dialog.OK = function () {
        var url = defaultURL + "?action=" + cutCopyOperation + "&value1=" + encodeURIComponent(currentNode.path) + "&value2=" + encodeURIComponent(cutCopyFiles.join("|"));
        var result = executeHttpRequest("GET", url, null);

        if (result == "OK") {
            dialog.Content = "The paste operation is successful";
            currentNode.Refresh();
        } else {
            dialog.Content = "<span tyle='color:red'> Failed to paste, please try again!</span>";
        }
        dialog.Show(1);
        dialog.OK = dialog.Close;
    }
}