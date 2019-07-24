using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using SharpZipLib;

namespace NetDisc
{
    /// <summary>
    /// WebExplorerFunc 的摘要说明
    /// </summary>
    public class WebExplorerFunc : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //互不影响
            context.Response.Buffer = true;
            // 不缓存
            context.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(0);
            context.Response.Expires = 0;

            //设置异步请求头部
            context.Response.AddHeader("Pragma", "No-Cache");

            //接受action,区分动作/操作类型
            string action = context.Request["action"];

            switch (action)
            {
                case "LIST": //get the file list
                    ResponseList(context);
                    break;
                case "DOWNLOAD": //download the file
                    DownLoadFile(context);
                    break;
                case "GETEDITFILE": //read file content
                    GetEditFileContent(context);
                    break;
                case "SAVAEDITFILE": //save the editted file
                    SaveFile(context, false);
                    break;
                case "NEWDIR": //new directiory
                    NewDirectory(context);
                    break;
                case "NEWFILE":
                    SaveFile(context, true);
                    break;
                case "DELETE": //delete operation
                    Delete(context);
                    break;
                case "CUT":
                    CutCopy(context, "cut");
                    break;
                case "COPY":
                    CutCopy(context, "copy");
                    break;
                case "UPLOAD": //upload file
                    upload(context);
                    break;
                case "RENAME":
                    Rename(context);
                    break;
                case "ZIP":
                    Zip(context);
                    break;
                case "UNZIP":
                    Unzip(context);
                    break;
                case "DOWNLOADS":
                    Downloads(context);
                    break;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #region 具体的操作实现过程
        /// <summary>
        /// 获取文件及文件夹路径列表
        /// </summary>
        /// <param name="context"></param>
        private void ResponseList(HttpContext context)
        {
            string value1 = context.Request["value1"]; //获取参数 {key:value}
            // in order to return back json
            //insert an array and set the max size as 500
            StringBuilder json = new StringBuilder("var GetList = {\"Directory\":[", 500);
            string path = context.Server.MapPath(value1); //从虚拟路径获取要列举的物理路径

            string[] dir = Directory.GetDirectories(path); //获取指定路径下面所有文件夹
            string[] files = Directory.GetFiles(path);

            foreach (string d in dir)
            {
                DirectoryInfo info = new DirectoryInfo(d);
                //{"Name": "ProgramFiles","LastModify":"2019-09-20 12:12:88"}
                json.Append("{\"Name\":\"" + info.Name + "\", \"LastModify\":\"" + info.LastWriteTime + "\"},");
            }

            string temp = json.ToString();
            if (temp.EndsWith(",")) //remove the last comma
            {
                temp = temp.Substring(0, temp.Length - 1);
            }

            json = new StringBuilder(temp); //create the json again
            json.Append("],\"File\":["); //拼接文件

            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);

                //换算尺寸和单位
                string size = null;
                if (info.Length > 1024 * 1024) //M
                {                                   //define the precision
                    size = ((double)info.Length / 1024 / 1024).ToString("F2") + " MB";
                }
                else if (info.Length > 1024)
                {
                    size = ((double)info.Length / 1024).ToString("F2") + " KB";
                }
                else
                {
                    size = ((double)info.Length).ToString() + " B";
                }

                json.Append("{\"Name\":\"" + info.Name + "\",\"Size\":\""+size+"\", \"LastModify\":\"" + info.LastWriteTime + "\"},");

            }

            temp = json.ToString();
            if (temp.EndsWith(",")) //remove the last comma
            {
                temp = temp.Substring(0, temp.Length - 1);
            }

            json = new StringBuilder(temp); //create the json again
            json.Append("]}");

            //输出json
            context.Response.Write(json.ToString());

        }

        /// <summary>
        /// 下载文件操作
        /// </summary>
        /// <param name="context"></param>
        private void DownLoadFile(HttpContext context)
        {
            string value1 = context.Request["value1"];
            //split the file address
            string[] files = value1.Split('|');
            foreach (string item in files)
            {
                //get the absolute address
                string path = context.Server.MapPath(item);
                if (File.Exists(path))
                {
                    DownLoadFIle.ResponseFile(path, context, true);
                }
            }

        }

        /// <summary>
        /// read the file content from server
        /// </summary>
        /// <param name="context"></param>
        private void GetEditFileContent(HttpContext context)
        {
            string path = context.Server.MapPath(context.Request["value1"]);
            context.Response.Write(File.ReadAllText(path, Encoding.UTF8));
        }

        /// <summary>
        /// save the file that is already editted / newly created
        /// </summary>
        /// <param name="context"></param>
        private void SaveFile(HttpContext context, bool isNew)
        {
            //get the  physical path of file
            string path = context.Server.MapPath(context.Request["value1"]);
            if ((isNew & File.Exists(path)) | (!isNew & !File.Exists(path))) //created new file && but exist OR edit file but not exist
            {
                return;
            }
            string content = context.Request["content"];
            StreamWriter sw = File.CreateText(path);
            sw.Write(content);
            sw.Close();
            context.Response.Write("OK");

        }

        /// <summary>
        /// New directory
        /// </summary>
        /// <param name="context"></param>
        private void NewDirectory(HttpContext context)
        {
            //the first thing is get the path
            string path = context.Request["value1"];
            //virtual directory to the physical directory
            Directory.CreateDirectory(context.Server.MapPath(path));
            context.Response.Write("OK");
        }

        /// <summary>
        /// delete a file/directory or a bunch of files 
        /// </summary>
        /// <param name="context"></param>
        private void Delete(HttpContext context)
        {
            //seperate to the file list [value1 is full virtual path, not only file name]
            string[] files = context.Request["value1"].Split('|');
            foreach (string file in files)
            {
                //find the physical path
                string path = context.Server.MapPath(file);
                if (File.Exists(path))
                {
                    File.Delete(path);
                } else if (Directory.Exists(path))
                {
                    //not directly remove the folder if it is not empty
                    try
                    {
                        Directory.Delete(path, false);
                    }
                    catch (IOException)
                    {
                        if (Directory.GetDirectories(path).GetLength(0) > 0)
                        {
                            context.Response.Write("NOTEMPTY");
                            return;
                        }
                        else
                        {
                            Directory.Delete(path);
                        }
                    }
                }
            }
            context.Response.Write("OK");
        }

        /// <summary>
        /// delete the source - cut
        /// keep the source - copy
        /// and keep the selected file(s)/folder(s)
        /// </summary>
        /// <param name="context"></param>
        private void CutCopy(HttpContext context, string flag)
        {
            //the destination path
            string path = context.Server.MapPath(context.Request["value1"]);
            string[] files = context.Request["value2"].Split('|');
            foreach (string file in files)
            {
                //get the physical path for all selected files
                string filepath = context.Server.MapPath(file);
                //get the file name
                string fileName = Path.GetFileName(filepath);
                if (File.Exists(filepath))
                {
                    if (flag == "cut")
                    {
                        try
                        {
                            File.Move(filepath, path + fileName);
                        }
                        catch (IOException)
                        {
                            if (File.Exists(path + "\\" + fileName)) {
                                context.Response.Write("EXIST");
                                return;
                            }
                        }
                    }
                    else //flag == "copy"
                    {
                        try
                        {
                            File.Copy(filepath, path + fileName);
                        }
                        catch (IOException)
                        {
                            if (File.Exists(path + "\\" + fileName))
                            {
                                context.Response.Write("EXIST");
                                return;
                            }
                        }
                    }
                } else if (Directory.Exists(filepath))
                {
                    if (flag == "cut")
                    {
                        Directory.Move(filepath, path + fileName);
                    }
                    else //flag == "copy"
                    {
                        //new function for copying dir
                        CopyDirectory(filepath, path + fileName);
                    }
                }

            }
            context.Response.Write("OK");
        }

        //help for large size file transfer
        /// <summary>
        /// copy the directory
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        private void CopyDirectory(string source, string destination)
        {
            // to exclude the exception that two path are same
            if (!destination.StartsWith(source, StringComparison.CurrentCultureIgnoreCase))
            {
                DirectoryInfo src = new DirectoryInfo(source);
                DirectoryInfo des = new DirectoryInfo(destination);

                //Create the directory successful
                des.Create();

                //copy all the file inside
                FileInfo[] sFiles = src.GetFiles();
                for (int i = 0; i < sFiles.Length; ++i)
                {
                    //"true" means it will cover the file with same name
                    File.Copy(sFiles[i].FullName, des.FullName + "\\" + sFiles[i].Name, true);
                }
                //copy all the sub-folder inside
                DirectoryInfo[] sDirs = src.GetDirectories();
                for (int i = 0; i < sDirs.Length; ++i)
                {
                    CopyDirectory(sDirs[i].FullName, des.FullName + "\\" + sDirs[i].Name);
                }
            }
        }

        /// <summary>
        /// compress the file(s)
        /// </summary>
        /// <param name="context"></param>
        private void Zip(HttpContext context)
        {
            string zipFile = context.Server.MapPath(context.Request["value1"]);
            string[] filepkg = context.Request["value2"].Split('|');
            List<string> files = new List<string>();
            List<string> dirs = new List<string>();

            //put all the files and directories that needs to 
            //be compressed into the list
            foreach (string item in filepkg)
            {
                string path = context.Server.MapPath(item);
                //distinguish between file and directory
                if (File.Exists(path))
                {
                    files.Add(path);
                } else if (Directory.Exists(path))
                {
                    dirs.Add(path);
                }
            }
            //source path/ destination path / password/ separate/ files array/ directory array
            ZipClass.Zip(Path.GetDirectoryName(zipFile) + "\\",
                zipFile, "", true, files.ToArray(), dirs.ToArray());

            context.Response.Write("OK");
        }

        private void Unzip(HttpContext context)
        {
            string unZipDir = context.Server.MapPath(context.Request["value1"]);
            string[] zipFiles = context.Request["value2"].Split('|');
            int n = zipFiles.Length;
            foreach (string item in zipFiles)
            {
                ZipClass.UnZip(context.Server.MapPath(item), unZipDir, "");
            }
            context.Response.Write("OK");
        }

        /// <summary>
        /// upload file(s)
        /// </summary>
        /// <param name="context"></param>
        private void upload(HttpContext context)
        {
            string path = context.Server.MapPath(context.Request["value1"]);
            //collect the uploaded file
            HttpFileCollection files = context.Request.Files;

            //calculate the total size
            long allSize = 0;
            for (int i = 0; i < files.Count; ++i)
            {
                allSize += files[i].ContentLength;
            }
            if (allSize > 10 * 1024 * 1024)//max size is 10m
            {
                context.Response.Write("Exceeding the upper limit");
            }
            for (int i = 0; i < files.Count; ++i)
            {
                files[i].SaveAs(path + Path.GetFileName(files[i].FileName));
            }
            context.Response.Write("OK");
        }

        /// <summary>
        /// download more than one files
        /// </summary>
        /// <param name="context"></param>
        private void Downloads(HttpContext context)
        {
            //define the zip file's location [target container]
            string zipFile = context.Server.MapPath("#download.zip");
            string[] fd = context.Request["value1"].Split('|');
            List<string> files = new List<string>();
            List<string> dirs = new List<string>();

            foreach (string item in fd)
            {
                string p = context.Server.MapPath(item);
                if (File.Exists(p))
                {
                    files.Add(p);
                }
                else if (Directory.Exists(p))
                {
                    dirs.Add(p);
                }
            }
            //create zip package
            ZipClass.Zip(Path.GetDirectoryName(zipFile) + "\\", zipFile, "",
                true, files.ToArray(), dirs.ToArray());
            DownLoadFIle.ResponseFile(zipFile, context, false);
        }
        

        private void Rename(HttpContext context)
        {
            string oldName = context.Server.MapPath(context.Request["value1"]);
            string newName = context.Server.MapPath(context.Request["value2"]);

            File.Move(oldName, newName);
            context.Response.Write("OK");
        }
        #endregion
    }
}