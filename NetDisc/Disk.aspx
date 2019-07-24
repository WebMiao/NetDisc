<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Disk.aspx.cs" Inherits="NetDisc.Disk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <title></title>
    <script>
        const urlParams = new URLSearchParams(window.location.search);
        const coursename = urlParams.get('coursename');
        const courseid = urlParams.get('courseid');
        //alert(courseid);
    </script>
    <script src="js/Ajax.js"></script>
    <script src="js/Tree.js"></script>
    <script src="js/Dialog.js"></script>
    <script src="js/Common.js"></script>
    <link rel="shortcut icon" href="#" />
    <link href="images/dialog/Dialog.css" rel="stylesheet" />
    <link href="css/WebExplorer.css" rel="stylesheet" />
    <script src="/ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="fileExplorer">
        <div id="tree"></div>
        <div id="rightPanel">
            The current position is: <span id="pathString"></span>
            <hr>
            <!-- this is the menu of operations-->
            <div id="menu">
                <div class="menuItem" onclick="javascript:gotoParentDirctory();">
                    <img src="images/up.png" />
                    <div class="tipText">Upper Layer</div>
                </div>

                <div class="menuItem" onclick="javascript:goRoot();">
                    <img src="images/home.png" />
                    <div class="tipText">Home</div>
                </div>

                <div class="menuItem" onclick="javascript: refresh();">
                    <img src="images/refresh.png" />
                    <div class="tipText">Refresh</div>
                </div>

                <div class="menuItem" onclick="javascript:newDirectory();">
                    <img src="images/newfolder.png" />
                    <div class="tipText">New Folder</div>
                </div>

                <div class="menuItem" onclick="javascript: newFile();">
                    <img src="images/newfile.png" />
                    <div class="tipText">New File</div>
                </div>

                <div class="menuItem" onclick="javascript: del();">
                    <img src="images/delete.png" />
                    <div class="tipText">Delete</div>
                </div>

                <div class="menuItem" onclick="javascript:cut();">
                    <img src="images/cut.png" />
                    <div class="tipText">Cut</div>
                </div>

                <div class="menuItem" onclick="javascript:copy();">
                    <img src="images/copy.png" />
                    <div class="tipText">Copy</div>
                </div>

                <div class="menuItem" onclick="javascript: paste();">
                    <img src="images/paste.png" />
                    <div class="tipText">Paste</div>
                </div>

                <div class="menuItem" onclick="javascript: zipFile();">
                    <img src="images/archiveL.png" />
                    <div class="tipText">Zip File</div>
                </div>

                <div class="menuItem" onclick="javascript: unzipFile();">
                    <img src="images/unzip.png" />
                    <div class="tipText">Unzip File</div>
                </div>

                <div class="menuItem" onclick="javascript:downloadFiles();">
                    <img src="images/download.png" />
                    <div class="tipText">Download</div>
                </div>

                <div class="menuItem" onclick="javascript: uploadFile();">
                    <img src="images/upload.png" />
                    <div class="tipText">Upload</div>
                </div>
            </div>
            <!-- the end of the menu-->
            <hr>
            <div id="fileListHead">
                <div style="float: left; padding-top:4px; padding-bottom:2px;"><input type="checkbox" id="checkAll" onclick="javascript: selectAll();" /></div>
                <div class="fileType">Type</div>
                <div class="fileName">Name</div>
                <div class="fileSize">Size</div>
                <div class="lastUpdate">Last Update</div>
                <div class="rename">Rename</div>
            </div>
            <div id="fileList"></div>
        </div>
    </div>
    <script src="js/WebExplorerMain.js"></script>
</asp:Content>
