namespace ArrayProblems.Medium._54_SpiralMatrix;

/// <summary>
///  https://leetcode.com/problems/spiral-matrix/description/?envType=problem-list-v2&envId=array&difficulty=MEDIUM
/// </summary>
public class Problem
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var matrixSize = matrix.Length * matrix[0].Length;
        var result = new List<int>();

        var topBound = -1;
        var bottomBound = matrix.Length;
        var leftBound = -1;
        var rightBound = matrix[0].Length;
        var row = 0;
        var col = 0;

        while (topBound < bottomBound && leftBound < rightBound && result.Count < matrixSize)
        {
            // Go right
            while (col < rightBound && result.Count < matrixSize)
            {
                result.Add(matrix[row][col]);
                col++;
            }

            col--;
            row++;
            topBound++;

            // Go down
            while (row < bottomBound && result.Count < matrixSize)
            {
                result.Add(matrix[row][col]);
                row++;
            }

            row--;
            col--;
            rightBound--;

            // Go left
            while (col > leftBound && result.Count < matrixSize)
            {
                result.Add(matrix[row][col]);
                col--;
            }

            col++;
            row--;
            bottomBound--;

            // Go up
            while (row > topBound && result.Count < matrixSize)
            {
                result.Add(matrix[row][col]);
                row--;
            }

            row++;
            col++;
            leftBound++;
        }

        return result;
    }
}