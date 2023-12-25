using System.Windows;
using System.Windows.Controls;

namespace WpfHello
{
    /// <summary>
    /// ChallengeControlWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ChallengeControlWindow : Window
    {
        public ChallengeControlWindow()
        {
            InitializeComponent();
        }

        private void RoundConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            int[,]? myArray = null;
            var selectedRound = int.Parse(((ComboBoxItem)RoundComboBox.SelectedItem)?.Content.ToString() ?? "1");
            switch (selectedRound)
            {
                case 1:
                    myArray = new int[2, 3]; // 第一关为2*3的大小
                    GetRandomMatrix(myArray);
                    break;
                case 2:
                    myArray = new int[3, 3]; // 第二关为3*3的大小
                    GetRandomMatrix(myArray);
                    break;
                case 3:
                    myArray = new int[4, 4]; // 第三关为4*4的大小
                    GetRandomMatrix(myArray);
                    break;
            }
            var map = new Map(myArray);
            var puzzleWindow = new PuzzleWindow(map);
            puzzleWindow.Show();

            // 关闭当前窗口
            Close();
        }

        //保证有解的前提下随机打乱二维数组
        private static void GetRandomMatrix(int[,] myArray)
        {
            do
            {
                JudgeSolvable.GetRandomMatrix(myArray);
            } while (JudgeSolvable.IsSolvable(myArray));
        }
    }
}
