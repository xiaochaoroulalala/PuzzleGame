using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace WpfHello;

/// <summary>
///     Interaction logic for PuzzleWindow.xaml
/// </summary>
public partial class PuzzleWindow : Window
{
    private readonly Map _map;

    public PuzzleWindow(Map map)
    {
        InitializeComponent();
        _map = map;

        ChangeWindowSize();

        MapPainter.DrawMap(_map, PuzzleGrid, _map.IsSolved());
    }

    private void ChangeWindowSize()
    {
        var bitmap = new BitmapImage(new Uri(MainWindow.ImgUri, UriKind.Relative));
        Width = bitmap.PixelWidth * 2;
        Height = bitmap.PixelHeight * 2;
    }

    private void PuzzleGrid_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key is not (Key.Up or Key.Down or Key.Left or Key.Right)) return;
        _map.Move(e.Key);
        MapPainter.DrawMap(_map, PuzzleGrid, _map.IsSolved());
        if (_map.IsSolved())
        {
            var successWindow = new SuccessWindow();
            successWindow.Show();
        }
    }

}