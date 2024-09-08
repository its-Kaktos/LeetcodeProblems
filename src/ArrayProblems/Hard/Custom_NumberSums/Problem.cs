namespace ArrayProblems.Hard.Custom_NumberSums;

/// <summary>
/// This is a custom problem. solve the Number sums game on IPhone
/// </summary>
public class Problem
{
    public int[][] SumNumbers(int[][] nums, int[] horizontalSums, int[] verticalSums)
    {
        var result = new int[nums.Length][];
        for (var i = 0; i < result.Length; i++)
        {
            var a = new int[nums.Length];
            Array.Fill(a, -1);
            result[i] = a;
        }

        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = 0; j < nums[i].Length; j++)
            {
                if (nums[i][j] > verticalSums[i] || nums[i][j] > horizontalSums[j])
                {
                    result[i][j] = 0;
                }
            }
        }

        return result;
    }
}