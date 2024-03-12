using System;

class Program
{
    static void Main()
    {
        // 示例矩阵
        int[,] matrix = {
            {1, 2, 3, 4},
            {5, 1, 2, 3},
            {9, 5, 1, 2}
        };

        bool result = IsToeplitzMatrix(matrix);
        Console.WriteLine(result);  // 输出 True
    }

    static bool IsToeplitzMatrix(int[,] matrix)
    {
        // 获取矩阵的行数和列数
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        // 遍历矩阵中每个元素，除了第一行和第一列
        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j < cols; j++)
            {
                // 检查元素是否与其左上角的元素相同
                if (matrix[i, j] != matrix[i - 1, j - 1])
                {
                    return false;
                }
            }
        }

        // 如果遍历完所有元素都满足条件，返回 true
        return true;
    }
}
