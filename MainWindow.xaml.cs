using System;
using System.Windows;

namespace WpfHello
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string ImgUri = "Img/classic.png";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChallengeButtonClick(object sender, RoutedEventArgs e)
        {
            var challengeControlWindow = new ChallengeControlWindow();
            challengeControlWindow.Show();
        }

        private void CustomButtonClick(object sender, RoutedEventArgs e)
        {
            var customControlWindow = new CustomControlWindow();
            customControlWindow.Show();
        }

        private void HelpButtonClick(object sender, RoutedEventArgs e)
        {
            var helpWindow = new HelpWindow();
            helpWindow.Show();
        }

        private void ChangeButtonClick(object sender, RoutedEventArgs e)
        {
            var imgChangeWindow = new ImgChangeWindow();
            imgChangeWindow.Show();
        }

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
