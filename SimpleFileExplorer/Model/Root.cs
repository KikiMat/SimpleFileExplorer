using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SimpleFileExplorer.Model
{
    public class Root : TreeViewItem
    {
        public Root()
        {
        }
        public string Type { get; set; }
        public string RootName { get; set; }
        public BitmapSource SystemIcon { get; set; }


    }
}
