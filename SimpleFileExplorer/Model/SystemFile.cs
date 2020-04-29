using System;
using System.Windows.Media.Imaging;


namespace SimpleFileExplorer.Model
{
    public class SystemFile
    {
        public string FileName { get; private set; }
        public string FriendlyName { get; set; }
        public string DateModified { get; private set; }
        public string FileType { get; private set; }
        public string Extension { get; set; }
        public string Size { get; private set; }
        public DateTime LastWriteTime { get; set; }
        public BitmapSource SystemIcon { get; set; }

        public SystemFile(string fileName, string fileType, string extension, DateTime lastWriteTime, BitmapSource systemIcon)
        {
            this.FileName = fileName;
            this.FileType = fileType;
            this.Extension = extension;
            this.LastWriteTime = lastWriteTime;
            this.SystemIcon = systemIcon;
            FriendlyName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
        }
        public SystemFile(string fileName)
        {
            this.FileName = fileName;
        }
    }
}
