using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NetDisc
{
    public static class DownLoadFIle
    {
        /// <summary>
        /// Solve the download operation
        /// 将要下载的写入到输出流（避免直接打开操作），二进制数据流
        /// </summary>
        /// <param name="path"></param>
        /// <param name="context"></param>
        public static void ResponseFile(string path, HttpContext context)
        {
            context = HttpContext.Current;
            Stream iStream = null; //define a bit stream
            
            //the maximum size for one time reading
            byte[] buffer = new byte[1024 * 1024]; 
            int length = 0;
            long dataToRead;
            string fileName = Path.GetFileName(path); //get the specific file's name and extract tag

            //general file type
            iStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);

            dataToRead = iStream.Length;
            //define the output type as stream
            context.Response.ContentType = "application/octet-stream";
            //define the display method
            context.Response.AddHeader("Content-Disposition",
                "attachment;filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));

            while(dataToRead > 0) //whether read into bit stream or not
            {
                //judge the client is connected [save server resource]
                if (context.Response.IsClientConnected)
                {
                    length = iStream.Read(buffer, 0, 1024 * 1024);
                    context.Response.OutputStream.Write(buffer, 0, length);
                    context.Response.Flush();

                    buffer = new byte[1024 * 1024];
                    dataToRead = dataToRead - length;
                }
                else
                {
                    dataToRead = -1; //set that nothing is read
                }
            }
            iStream.Close();
        }
    }
}