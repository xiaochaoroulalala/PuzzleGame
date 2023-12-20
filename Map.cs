using System;
using System.Media;
using System.Windows.Input;

namespace WpfHello;

public class Map
{
    private readonly int[,] _matrix;

    private int _zeroCol;

    private int _zeroRow;

    public Map(int[,] matrix)
    {
        _matrix = matrix;
        var counter = 0;
        for (var i = 0; i < RowCount; i++)
            for (var j = 0; j < ColCount; j++)
                if (_matrix[i, j] == 0)
                {
                    _zeroRow = i;
                    _zeroCol = j;
                    counter++;
                }

        if (counter != 1) throw new Exception("Invalid map");
    }

    public int ColCount => _matrix.GetLength(1);
    public int RowCount => _matrix.GetLength(0);
    public int this[int i, int j] => _matrix[i, j];

    public int GetRealColIndexFromId(int id)
    {
        return (id - 1) % ColCount;
    }

    public int GetRealRowIndexFromId(int id)
    {
        return (id - 1) / ColCount;
    }

    public bool IsSolved()
    {
        for (var i = 0; i < RowCount; i++)
            for (var j = 0; j < ColCount; j++)
                if ((i != RowCount - 1 || j != ColCount - 1) && _matrix[i, j] != i * ColCount + j + 1)
                    return false;

        return true;
    }

    public bool IsValidMove(Key key)
    {
        return key switch
        {
            Key.Up => (_zeroRow < RowCount - 1),
            Key.Down => (_zeroRow > 0),
            Key.Left => (_zeroCol < ColCount - 1),
            Key.Right => (_zeroCol > 0),
            _ => false,
        };
    }

    public void Move(Key key)
    {
        if (!IsValidMove(key))
        {
            PlayErrorSound();
            return;
        }

        switch (key)
        {
            case Key.Up:
                MoveUp();
                break;

            case Key.Down:
                MoveDown();
                break;

            case Key.Left:
                MoveLeft();
                break;

            case Key.Right:
                MoveRight();
                break;
        }
    }

    private void MoveRight()
    {
        if (_zeroCol == 0) return;
        _matrix[_zeroRow, _zeroCol] = _matrix[_zeroRow, _zeroCol - 1];
        _matrix[_zeroRow, _zeroCol - 1] = 0;
        _zeroCol--;
    }

    private void MoveLeft()
    {
        if (_zeroCol == ColCount - 1) return;
        _matrix[_zeroRow, _zeroCol] = _matrix[_zeroRow, _zeroCol + 1];
        _matrix[_zeroRow, _zeroCol + 1] = 0;
        _zeroCol++;
    }

    private void MoveDown()
    {
        if (_zeroRow == 0) return;
        _matrix[_zeroRow, _zeroCol] = _matrix[_zeroRow - 1, _zeroCol];
        _matrix[_zeroRow - 1, _zeroCol] = 0;
        _zeroRow--;
    }

    private void MoveUp()
    {
        if (_zeroRow == RowCount - 1) return;
        _matrix[_zeroRow, _zeroCol] = _matrix[_zeroRow + 1, _zeroCol];
        _matrix[_zeroRow + 1, _zeroCol] = 0;
        _zeroRow++;
    }

    private void PlayErrorSound()
    {
        try
        {
            SystemSounds.Exclamation.Play();
        }
        catch (Exception ex)
        {
            // 处理播放提示音错误的异常
            Console.WriteLine($"Error playing error sound: {ex.Message}");
        }
    }
}