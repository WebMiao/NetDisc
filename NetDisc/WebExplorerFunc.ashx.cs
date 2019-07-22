using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

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
                    SaveFile(context,false);
                    break;
                case "NEWDIR": //new directiory
                    break;
                case "DELETE": //delete operation
                    break;
                case "CUT":
                    break;
                case "COPY":
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

                json.Append("{\"Name\":\"" + info.Name + "\", \"LastModify\":\"" + info.LastWriteTime + "\"},");

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
            foreach(string item in files)
            {
                //get the absolute address
                string path = context.Server.MapPath(item);
                if (File.Exists(path))
                {
                    DownLoadFIle.ResponseFile(path, context);
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
            if ((isNew & File.Exists(path))|(!isNew & !File.Exists(path))) //created new file && but exist OR edit file but not exist
            {
                return;
            }
            string content = context.Request["content"];
            StreamWriter sw = File.CreateText(path);
            sw.Write(content);
            sw.Close();
            context.Response.Write("OK");

        }
        #endregion
    }
}