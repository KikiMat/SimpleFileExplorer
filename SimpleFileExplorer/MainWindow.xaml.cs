using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using SimpleFileExplorer.Model;
using SimpleFileExplorer.Classes;

namespace SimpleFileExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        #region Properties
        public ObservableCollection<SystemFile> FilesList { get; set; } = new ObservableCollection<SystemFile>();
        public ObservableCollection<Root> Roots { get; set; } = new ObservableCollection<Root>();
        public string Text { get; set; }

        #endregion
        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
            InitializeTree();
        }

        #endregion

        #region Events

        /// <summary>
        /// Using lazy loading so every time we expand a node of the tree we load its children
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void folder_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem items = (TreeViewItem)sender;
            Root item = items as Root;

            if (item.Items.Count == 1 && item.Items[0].ToString() == "Dummy")
            {
                item.Items.Clear();
                try
                {
                    foreach (string s in Directory.GetFileSystemEntries(item.Tag.ToString()))
                    {
                        Root subitem = new Root();
                        subitem.Type = "Folder";
                        subitem.Header = s.Substring(s.LastIndexOf("\\") + 1);
                        subitem.RootName = subitem.Header.ToString();
                        subitem.SystemIcon = GetIconFromDll(s);
                        subitem.Tag = s;
                        subitem.Items.Add("Dummy");
                        subitem.Expanded += new RoutedEventHandler(folder_Expanded);
                        item.Items.Add(subitem);
                    }
                }
                catch (Exception ex) { }
            }
        }

        /// <summary>
        /// When we select a folder on the left panel, we see its content on the Details panel.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void foldersItem_SelectedItemChanged(object sender, RoutedEventArgs e)
        {
            TreeView tree = (TreeView)sender;
            TreeViewItem temp = ((TreeViewItem)tree.SelectedItem);
            string path = temp.Tag.ToString();
            Text = path;
            Path.Text = Text;
            LoadFiles(path);
        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadFiles(Path.Text);
            ///TO DO
            ///Find the node on the folder tree view
            //Tree.SelectedItem = Path.Text;

        }
        private void BackOneLevel_Click(object sender, RoutedEventArgs e)
        {
            if (Path.Text != "")
            {
                string CurrentPath = Path.Text.ToString();
                if (Directory.GetParent(CurrentPath) != null)
                {
                    string ParentPath = Directory.GetParent(CurrentPath).ToString();
                    Path.Text = ParentPath;
                    LoadFiles(ParentPath);
                }
            }

        }
        void LabelMouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            SystemFile obj = item.Content as SystemFile;
            Path.Text = obj.FileName;
            LoadFiles(obj.FileName);
        }

        #endregion

        #region Methods

        /// <summary>
        /// This loads the Logical Drives 
        /// </summary>
        public void InitializeTree()
        {
            foreach (string s in Directory.GetLogicalDrives())
            {
                Root item = new Root();
                //TreeViewItem item = new TreeViewItem();
                item.Type = "Drive";
                item.Header = s;
                item.RootName = s.ToString();
                item.SystemIcon = GetIconFromDll(s);
                item.Tag = s;
                item.Items.Add("Dummy");
                item.Expanded += new RoutedEventHandler(folder_Expanded);
                Tree.Items.Add(item);
            }


        }

        /// <summary>
        /// Populates the list to load in the ListBox control
        /// </summary>
        /// <param name="path"></param>
        public void LoadFiles(string path)
        {
            FilesList.Clear();

            FilesList = GetFilesFromDirectory(path);
            test.ItemsSource = FilesList;
        }
        /// <summary>
        /// Gets the subdirectories and files of the given folder.
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public ObservableCollection<SystemFile> GetFilesFromDirectory(string path)
        {
            ObservableCollection<SystemFile> Files = new ObservableCollection<SystemFile>();

            try
            {
                CountPerCategoryStats.ItemsTotal = 0;
                CountPerCategoryStats.FilesTotal = 0;
                CountPerCategoryStats.FoldersTotal = 0;

                string[] directoryEntries = Directory.GetFileSystemEntries(path);

                foreach (var str in directoryEntries)
                {
                    FileInfo fi = new FileInfo(str);
                    FileAttributes attr = File.GetAttributes(str);

                    if (fi.Extension == "")
                    {
                        //directory
                        Files.Add(new SystemFile(str.ToString(), "folder", fi.Extension, fi.LastWriteTime, GetIconFromDll(str)));
                        CountPerCategoryStats.FoldersTotal++;
                    }
                    else
                    {
                        //file
                        Files.Add(new SystemFile(str.ToString(), "file", fi.Extension, fi.LastWriteTime, GetIconFromDll(str)));
                        CountPerCategoryStats.FilesTotal++;
                    }
                }

            }
            catch (Exception ex) { }

            CountPerCategoryStats.ItemsTotal = Files.Count;
            Statistics.DisplaySumStatistics(StatisticsArea);
            return Files;
        }
        public BitmapSource GetIconFromDll(string fileName)
        {
            BitmapSource myIcon = null;

            Boolean validDrive = false;
            foreach (DriveInfo D in System.IO.DriveInfo.GetDrives())
            {   //D.DriveType.
                if (fileName == D.Name)
                {
                    validDrive = true;
                }
            }

            if ((File.Exists(fileName)) || (Directory.Exists(fileName)) || (validDrive))
            {
                using (System.Drawing.Icon sysIcon = Icons.GetIcon(fileName, true))
                {
                    try
                    {
                        myIcon = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                                        sysIcon.Handle,
                                        System.Windows.Int32Rect.Empty,
                                        System.Windows.Media.Imaging.BitmapSizeOptions.FromWidthAndHeight(34, 34));
                    }
                    catch
                    {
                        myIcon = null;
                    }
                }
            }
            return myIcon;
        }
        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion // INotifyPropertyChanged Members


    }


}
