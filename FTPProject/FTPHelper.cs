using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace FTPProject
{
    public class FTPHelper
    {
        private string FtpUrl { get; set; }
        private string FtpAccount { get; set; }
        private string FtpPassword { get; set; }

        public FTPHelper()
        {
            FtpUrl = ConfigurationManager.AppSettings["FtpUrl"];
            FtpAccount = ConfigurationManager.AppSettings["FtpAccount"];
            FtpPassword = ConfigurationManager.AppSettings["FtpPassword"];
        }

        #region 方法

        /// <summary>
        /// 连接FTP
        /// </summary>
        public FtpWebRequest Connet(string uri, string method)
        {
            FtpWebRequest reqFtp = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            reqFtp.UseBinary = true;
            reqFtp.Credentials = new NetworkCredential(FtpAccount, FtpPassword);
            reqFtp.KeepAlive = false;
            reqFtp.Method = method;
            return reqFtp;
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <returns></returns>
        public bool UpLoad(string name, string value)
        {
            var ftpPath = FtpUrl + "/" + name;
            var reqFtp = Connet(ftpPath, WebRequestMethods.Ftp.UploadFile);
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            byte[] array = Encoding.UTF8.GetBytes(value);
            MemoryStream stream = new MemoryStream(array);
            try
            {
                Stream strm = reqFtp.GetRequestStream();
                var contentLen = stream.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = stream.Read(buff, 0, buffLength);
                }

                strm.Close();
                stream.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 在线查看
        /// </summary>
        /// <param name="name"></param>
        public string DownLoad(string name)
        {
            var reqFTP = Connet(FtpUrl + "/" + name, WebRequestMethods.Ftp.DownloadFile);
            try
            {
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(ftpStream, Encoding.UTF8);
                string result = reader.ReadToEnd();
                return result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// 判断ftp上的文件目录是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Exists(string path)
        {
            path = FtpUrl + "/" + path;
            var reqFtp = Connet(path, WebRequestMethods.Ftp.ListDirectory);
            FtpWebResponse resFtp = null;
            try
            {
                resFtp = (FtpWebResponse)reqFtp.GetResponse();
                var dd = resFtp.ContentLength;
                FtpStatusCode code = resFtp.StatusCode; //OpeningData
                resFtp.Close();
                return true;
            }
            catch
            {
                if (resFtp != null)
                {
                    resFtp.Close();
                }

                return false;
            }
        }

        /// <summary>
        ///在ftp服务器上创建文件目录
        /// </summary>
        /// <param name="dirName">文件目录</param>
        /// <returns></returns>
        public bool CreateDir(string dirName)
        {
            try
            {
                //bool b = Exists(dirName);
                //if (b) return true;
                FtpWebRequest reqFtp = Connet(FtpUrl + dirName, WebRequestMethods.Ftp.MakeDirectory);
                FtpWebResponse response = (FtpWebResponse)reqFtp.GetResponse();
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        #endregion
        }
    }
}
