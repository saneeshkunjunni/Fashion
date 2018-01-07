using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace FashionModeling.Models.Helpers
{
    public static class FileHelper
    {
        public static void SaveFile(byte[] content, string path)
        {
            string filePath = GetFileFullPath(path);
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }

            //Save file
            using (FileStream str = File.Create(filePath))
            {
                str.Write(content, 0, content.Length);
            }
        }

        public static string GetFileFullPath(string path)
        {
            string relName = path.StartsWith("~") ? path : path.StartsWith("/") ? string.Concat("~", path) : path;

            string filePath = relName.StartsWith("~") ? HostingEnvironment.MapPath(relName) : relName;

            return filePath;
        }

        public static bool CreateFolderIfNeeded(string path)
        {
            bool result = true;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    /*TODO: You must process this exception.*/
                    result = false;
                }
            }
            return result;
        }

        public static string ServerImagePath
        {
            get
            {
                try
                {
                    var path = ConfigurationManager.AppSettings["ImagePath"].ToString();
                    if (Directory.Exists(path))
                    {
                        return path;
                    }
                    return null;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        public static string DefaultProfileImage { get { return System.Web.HttpContext.Current.Server.MapPath("~/Images/Profiles/defaultProfile.jpg"); } }
        public static string ProfileImage(string profileId, string imageName = null)
        {
            string path = "";
            if (string.IsNullOrWhiteSpace(ServerImagePath))
            {
                path = System.Web.HttpContext.Current.Server.MapPath("~/Images/Profiles/");
                path = Path.Combine(path, profileId);
            }
            else
            {
                path = ServerImagePath;
                path = Path.Combine(path, profileId);
            }
            if (!string.IsNullOrWhiteSpace(imageName))
            {
                path = Path.Combine(path, imageName);
                path = File.Exists(path) ? path : DefaultProfileImage;
            }
            return path;

        }
        public static bool SaveProfileImage(HttpPostedFileBase myFile,string profileId)
        {
            if (myFile != null && myFile.ContentLength != 0)
            {
                var folderPath = ProfileImage(profileId);
                if (FileHelper.CreateFolderIfNeeded(folderPath))
                {
                    try
                    {
                        myFile.SaveAs(Path.Combine(folderPath, myFile.FileName));
                        return true;
                    }
                    catch (Exception) {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}