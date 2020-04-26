using System;
using System.Windows;
using DemoLibrary;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for SunInfo.xaml
    /// </summary>
    public partial class SunInfo : Window
    {
        public SunInfo()
        {
            InitializeComponent();
        }

        private async void loadSunInfo_Click(object sender, RoutedEventArgs e)
        {
            var sunData = await SunProcessor.LoadSunInformation();
            sunriseText.Text = $"Today's sunrise time in Strasbourg is: {sunData.Sunrise.ToLocalTime().ToShortTimeString()}";
            sunsetText.Text = $"Today's sunset time in Strasbourg is: {sunData.Sunset.ToLocalTime().ToShortTimeString()}";
        }
    }
}
