namespace ArrayProblems.Medium._48_Rotate_Image;

public class Problem
{
    /// <summary>
    /// My original WORKING answer
    /// </summary>
    /// <param name="matrix"></param>
    public void Rotate(int[][] matrix)
    {
        var colStart = 0;
        var colEnd = matrix.Length - 1;
        for (var row = 0; row < matrix.Length / 2; row++)
        {
            for (var col = colStart; col < colEnd; col++)
            {
                Move(matrix, row, col);
            }

            colStart++;
            colEnd--;
        }
    }

    private void Move(int[][] matrix, int row, int col)
    {
        var n = 0;
        var prev = matrix[row][col];
        while (n <= 3)
        {
            var newRow = col;
            var newCol = matrix.Length - 1 - row;
            (prev, matrix[newRow][newCol]) = (matrix[newRow][newCol], prev);
            n++;
            col = newCol;
            row = newRow;
        }
    }
}