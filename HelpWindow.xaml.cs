using System.Windows;
using System.Windows.Controls;

namespace WpfHello
{
    /// <summary>
    /// HelpWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HelpWindow : Window
    {
        public HelpWindow()
        {
            InitializeComponent();
            DisplayHelpInfo();
        }

        private void DisplayHelpInfo()
        {
            var dynamicTextBlock = new TextBlock
            {
                Text = "该游戏是将一张图片分割成若干块与一个空白块儿，并将其随机打乱。\n" +
                                    "玩家需要操控该空白块儿，通过上下左右按键,实现将空白块儿与其邻近的图块儿交换。\n" +
                                    "在经过一系列交换后，玩家将该图片还原即为成功。",
                FontSize = 20,
                TextAlignment = TextAlignment.Center, // 文本对齐方式为居中
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            // 将动态创建的 TextBlock 添加到窗口中的 Grid 控件
            HelpGrid.Children.Add(dynamicTextBlock);
        }
    }
}
