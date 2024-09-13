namespace DynamicProgramming.Medium._198_HouseRobber;

/// <summary>
/// https://leetcode.com/problems/house-robber/?envType=problem-list-v2&envId=dynamic-programming&difficulty=MEDIUM
/// </summary>
public class Problem
{
    /// <summary>
    /// https://www.youtube.com/watch?v=73r3KWiEvyk&ab_channel=NeetCode
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int Rob(int[] nums)
    {
        var rob1 = 0;
        var rob2 = 0;
        
        // [rob1, rob2, n, n+1, n1+2, ...]
        for (var i = 0; i < nums.Length; i++)
        {
            var temp = Math.Max(nums[i] + rob1, rob2);
            rob1 = rob2;
            rob2 = temp;
        }

        return rob2;
    }
    
    /// <summary>
    /// My original WORKING answer.
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int RobOrg(int[] nums)
    {
        var max = 0;

        var memo = new int?[nums.Length];
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            var result = RobInternal(nums, memo, i);

            max = Math.Max(result, max);
        }
        
        return max;
    }
    
    private int RobInternal(int[] nums, int?[] memo, int startFrom)
    {
        if (startFrom > nums.Length - 1) return 0;
        if (memo[startFrom].HasValue) return memo[startFrom]!.Value;

        var startFromNumber = nums[startFrom];
        var max = startFromNumber;
        for (var i = startFrom + 1; i < nums.Length; i++)
        {
            var result =  RobInternal(nums, memo, i + 1) + startFromNumber;
            max = Math.Max(max, result);
        }

        memo[startFrom] = max;
        return max;
    }
}