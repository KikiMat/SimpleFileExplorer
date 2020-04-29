using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SimpleFileExplorer.Classes
{
    public class Statistics
    {
        public static void DisplaySumStatistics(TextBlock block)
        {
            block.Text = "";

            Run run;

            block.FontSize = 12;
            block.FontWeight = FontWeights.Bold;

            block.Inlines.Add("Items: ");
            run = new Run(CountPerCategoryStats.ItemsTotal.ToString());
            run.FontWeight = FontWeights.Normal;
            run.FontSize = 15;
            block.Inlines.Add(run);

            block.Inlines.Add("     Files: ");
            run = new Run(CountPerCategoryStats.FilesTotal.ToString());
            run.FontWeight = FontWeights.Normal;
            run.FontSize = 15;
            block.Inlines.Add(run);

            block.Inlines.Add("     Folders: ");
            run = new Run(CountPerCategoryStats.FoldersTotal.ToString());
            run.FontWeight = FontWeights.Normal;
            run.FontSize = 15;
            block.Inlines.Add(run);

        }
    }
    public static class CountPerCategoryStats
    {
        public static int ItemsTotal { get; set; } = 0;
        public static int FilesTotal { get; set; } = 0;
        public static int FoldersTotal { get; set; } = 0;


    }
}
