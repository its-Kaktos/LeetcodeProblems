namespace DynamicProgramming.Medium._368_LargestDivisibleSubset;

/// <summary>
/// https://leetcode.com/problems/largest-divisible-subset/description/?envType=problem-list-v2&envId=dynamic-programming&difficulty=MEDIUM
/// </summary>
public class Problem
{
    /// <summary>
    /// https://www.youtube.com/watch?v=LeRU6irRoW0&ab_channel=NeetCodeIO
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public IList<int> LargestDivisibleSubset(int[] nums)
    {
        Array.Sort(nums);

        var dp = new List<List<int>>();
        for (var i = 0; i < nums.Length; i++)
        {
            dp.Add(new List<int> { nums[i] });
        }

        var result = new List<int>();

        for (var i = nums.Length - 1; i >= 0; i--)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[j] % nums[i] == 0)
                {
                    var temp = new List<int> { nums[i] };
                    temp.AddRange(dp[j]);

                    if (dp[i].Count < temp.Count) dp[i] = temp;
                }
            }

            if (result.Count < dp[i].Count) result = dp[i];
        }

        return result;
    }
}