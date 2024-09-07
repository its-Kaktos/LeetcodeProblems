using System.Diagnostics;

namespace ArrayProblems.Medium.RotateImageProblem;

/// <summary>
/// https://leetcode.com/problems/rotate-image/?envType=problem-list-v2&envId=array
/// </summary>
public class Problem
{
    /*
     input:
        [1, 2, 3],
        [4, 5, 6],
        [7, 8, 9]

        [5, 1, 9, 11], [2, 4, 8, 10], [13, 3, 6, 7], [15, 14, 12, 16]

    expected:
        [7, 4, 1],
        [8, 5, 2],
        [9, 6, 3]

        [15, 13, 2, 5], [14, 3, 4, 1], [12, 6, 8, 9], [16, 7, 10, 11]
     */
    public void Rotate(int[][] matrix)
    {
        var org = new List<List<int>>(matrix.Select(x => x.ToList()));

        var first = new List<int>(matrix[0]);
        var last = new List<int>(matrix[^1]);

        for (var i = matrix.Length - 2; i >= 1; i--)
        {
            var itemIndex = matrix.Length - 1 - i;
            for (var j = 0; j < matrix[i].Length; j++)
            {
                var arrayIndex = j;

                matrix[arrayIndex][itemIndex] = matrix[i][j];
            }
        }

        var x = matrix;
    }
}