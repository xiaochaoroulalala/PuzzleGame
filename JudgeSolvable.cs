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
                    if (puzzle[i] > 0 && puzzle[j] > 0 && puzzle[i] > puzzle[j])
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

            return inversions % 2 != 0;
        }
    }
}
