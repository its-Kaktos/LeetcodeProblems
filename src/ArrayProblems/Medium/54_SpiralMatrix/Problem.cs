namespace ArrayProblems.Medium._54_SpiralMatrix;

/// <summary>
///  https://leetcode.com/problems/spiral-matrix/description/?envType=problem-list-v2&envId=array&difficulty=MEDIUM
/// </summary>
public class Problem
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var result = new List<int>();

        var topBound = 0;
        var bottomBound = matrix.Length;
        var leftBound = -1;
        var rightBound = matrix[0].Length;
        var row = 0;
        var col = 0;

        while (topBound < bottomBound && leftBound < rightBound)
        {
            // Go right
            while (col < matrix[0].Length && col < rightBound)
            {
                result.Add(matrix[row][col]);
                col++;
            }

            col--;
            row++;
            topBound--;
            
            // Go down
            while (row < matrix.Length && row < bottomBound)
            {
                
                result.Add(matrix[row][col]);
                row++;
            }

            row--;
            col--;
            rightBound--;

            // Go left
            while (col >= 0 && col > leftBound)
            {
                
                result.Add(matrix[row][col]);
                col--;
            }

            col++;
            row--;
            bottomBound++;
            
            // Go up
            while (row >= 0 && row > topBound)
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