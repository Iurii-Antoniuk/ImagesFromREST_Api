using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using DemoLibrary;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int maxNumber = 0;
        private int currentNumber = 0;

        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private async Task LoadImage(int imageNumber = 0)
        {
            var comic = await ComicProcessor.LoadComic(imageNumber);

            if (imageNumber == 0)
            {
                maxNumber = comic.Num;
            }
            
            currentNumber = comic.Num;
            var imageSource = new Uri(comic.Img, UriKind.Absolute);
            comicImage.Source = new BitmapImage(imageSource);
        }
    }
}
