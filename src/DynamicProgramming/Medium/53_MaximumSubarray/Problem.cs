using System.Runtime.CompilerServices;

namespace DynamicProgramming.Medium._53_MaximumSubarray;

/// <summary>
/// https://leetcode.com/problems/maximum-subarray/?envType=problem-list-v2&envId=dynamic-programming&difficulty=MEDIUM
/// </summary>
public class Problem
{
    /// <summary>
    /// https://www.youtube.com/watch?v=hLPkqd60-28&ab_channel=GregHogg
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int MaxSubArray(int[] nums)
    {
        var maxSum = int.MinValue;
        var currentSum = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            currentSum += nums[i];
            maxSum = Math.Max(currentSum, maxSum);

            if (currentSum < 0) currentSum = 0;
        }

        return maxSum;
    }
}