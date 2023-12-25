using System;

namespace WpfHello
{
    internal class JudgeSolvable
    {
        public static void GetRandomMatrix(int[,] array)
        {
            var random = new Random();

            // 初始化数组
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = i * array.GetLength(1) + j; // 按顺序填充数组
                }
            }

            // Fisher-Yates 算法用于随机置换数组元素
            for (int i = array.GetLength(0) - 1; i > 0; i--)
            {
                for (int j = array.GetLength(1) - 1; j > 0; j--)
                {
                    int m = random.Next(0, i + 1);
                    int n = random.Next(0, j + 1);

                    (array[i, j], array[m, n]) = (array[m, n], array[i, j]);
                }
            }
        }

        // 将二维数组转换为一维数组
        public static int[] FlattenArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);
            var flattenedArray = new int[rows * columns];
            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    flattenedArray[index] = array[i, j];
                    index++;
                }
            }

            return flattenedArray;
        }

        //计算逆序数
        public static int CalculateInversions(int[] puzzle)
        {
            int inversions = 0;
            int length = puzzle.Length;

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (puzzle[i] > puzzle[j])
                    {
                        inversions++;
                    }
                }
            }

            return inversions;
        }

        //判断是否有解
        public static bool IsSolvable(int[,] puzzle)
        {
            var flattenedPuzzle = FlattenArray(puzzle);
            int inversions = CalculateInversions(flattenedPuzzle);
            if(puzzle.GetLength(0) == puzzle.GetLength(1))
                return inversions % 2 == 0;
            return IsSolvableNotSquareArray(puzzle, inversions);
        }

        private static bool IsSolvableNotSquareArray(int[,] puzzle, int inversions)
        {
            // 对于非方阵的情况，需要考虑空白格子的位置对逆序数的影响
            int emptyRow = -1; // 空白格子所在行
            for (int i = 0; i < puzzle.GetLength(0); i++)
            {
                for (int j = 0; j < puzzle.GetLength(1); j++)
                {
                    if (puzzle[i, j] == 0)
                    {
                        emptyRow = i;
                        break;
                    }
                }

                if (emptyRow != -1) // 找到空白格子位置后跳出循环
                {
                    break;
                }
            }

            // 判断是否有解
            if (puzzle.GetLength(0) % 2 == 1)
            {
                // 非方阵的行数为奇数
                return inversions % 2 == 0;
            }
            else
            {
                // 非方阵的行数为偶数
                if ((puzzle.GetLength(0) - emptyRow) % 2 == 0)
                {
                    return inversions % 2 != 0;
                }
                else
                {
                    return inversions % 2 == 0;
                }
            }
        }
    }
}
