using System.Windows;
using System.Windows.Controls;

namespace WpfHello
{
    /// <summary>
    /// CustomControlWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CustomControlWindow : Window
    {
        public CustomControlWindow()
        {
            InitializeComponent();
        }

        private void RowColConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedRows = int.Parse(((ComboBoxItem)RowsComboBox.SelectedItem)?.Content.ToString() ?? "2");
            var selectedColumns = int.Parse(((ComboBoxItem)ColumnsComboBox.SelectedItem)?.Content.ToString() ?? "2");

            if (selectedRows >= 2 && selectedRows <= 8 && selectedColumns >= 2 && selectedColumns <= 8)
            {
                var myArray = new int[selectedRows, selectedColumns];
                do
                {
                    JudgeSolvable.GetRandomMatrix(myArray);
                } while (JudgeSolvable.IsSolvable(myArray));
                var map = new Map(myArray);
                var puzzleWindow = new PuzzleWindow(map);
                puzzleWindow.Show();

                Close();
            }
            else
            {
                // 用户选择的行数和列数不在范围内
                MessageBox.Show("请选择2到8之间的行数和列数！");
            }
        }

    }

}
