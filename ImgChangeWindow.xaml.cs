using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfHello
{
    /// <summary>
    /// ImgChangeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ImgChangeWindow : Window
    {
        public ImgChangeWindow()
        {
            InitializeComponent();
        }

        private void ImgConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedContent = ((ComboBoxItem)ImgComboBox.SelectedItem)?.Content.ToString();
            MainWindow.ImgUri = selectedContent switch
            {
                "classic" => "Img/classic.png",
                "view" => "Img/view.png",
                "figure" => "Img/figure.png",
                _ => "Img/classic.png",
            };
            Close();
        }
    }
}
