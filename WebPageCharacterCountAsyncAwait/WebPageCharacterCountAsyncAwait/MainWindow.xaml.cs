using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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

namespace WebPageCharacterCountAsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = Url.Text.ToString();
            if (url !=string.Empty)
            {
                Result.Text = "Please wait...";
                long characters = GetPageLengthsAsync(url).Result;
               
                Result.Text = characters.ToString();
                //  Console.WriteLine($"1 page, {characters:N0} characters");


            }
        }

        public async Task<long> GetPageLengthsAsync(string args)
        {
            
            var client = new HttpClient();
            long pageLengths = 0;

            var uri = new Uri(Uri.EscapeUriString(args));
            string pageContents = await client.GetStringAsync(uri).ConfigureAwait(false);
            pageLengths=pageContents.Length;
           
            return pageLengths;
        }
    }
}

