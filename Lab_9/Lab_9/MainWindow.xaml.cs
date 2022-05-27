using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_9
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {


            int pageNumber = 1;
            int pageSize = 5;
            string snippetsType = "cs"; // C#

            PageReposne reponse = SnippetsUtils.FetchSnippets(pageNumber, pageSize, snippetsType);

            Console.WriteLine($"PageNumber: {reponse.PageNumber}");
            Console.WriteLine($"PagesCount: {reponse.PagesCount}");
            Console.WriteLine($"PageSize:   {reponse.PageSize}  ");
            Console.WriteLine($"TotalCount: {reponse.TotalCount}");

            Console.WriteLine();
            Console.WriteLine("Snippets:");

            foreach (SnippetReponse snippet in reponse.Batches)
                Console.WriteLine("    (" + snippet.Size + ")    " + snippet.Name + "    [" + snippet.Type + "]    " + snippet.CreationTime + "    " + snippet.UpdateTime);

            // Example ouput:
            //
            //     PageNumber: 1
            //     PagesCount: 12
            //     PageSize:   5
            //     TotalCount: 60
            //     
            //     Snippets:
            //         (1)    C# - fetch current Dirask snippets and display in console    [cs]    2022-05-27 03:23:49    2022-05-27 04:42:43
            //         (2)    C# - request web URL and get response content                [cs]    2022-05-27 02:05:36
            //         (1)    C# - async/await methods with synchronization                [cs]    2022-05-20 11:25:59    2022-05-20 21:16:17
            //         (2)    C# - lock statement usage example                            [cs]    2022-05-20 09:46:34    2022-05-22 01:37:16
            //         (2)    console.log() in C#                                          [cs]    2022-05-18 17:05:41    2022-05-22 19:09:07





        }

        private void Button_Click()
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
