namespace ArrayProblems.Easy._643_Maximum_Average_Subarray_1;

/// <summary>
/// https://leetcode.com/problems/maximum-average-subarray-i/?envType=problem-list-v2&envId=array&difficulty=EASY
/// </summary>
public class Problem
{
    // Example 1:
    // 
    // Input: nums = [1, 12, -5, -6, 50, 3], k = 4
    // Output: 12.75000
    // Explanation: Maximum average is (12 - 5 - 6 + 50) / 4 = 51 / 4 = 12.75
    //
    // Example 2:
    // Input: nums = [5], k = 1
    // Output: 5.00000
    public double FindMaxAverage(int[] nums, int k)
    {
        double sum = nums.Take(k).Sum();
        var mostAvg = sum / k;

        for (var i = k; i < nums.Length; i++)
        {
            sum -= nums[i - k];
            sum += nums[i];
            mostAvg = Math.Max(sum / k, mostAvg);
        }

        return mostAvg;
    }
}