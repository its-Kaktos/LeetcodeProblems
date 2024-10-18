namespace DynamicProgramming.Medium._91_DecodeWays;

/// <summary>
/// https://leetcode.com/problems/decode-ways/?envType=problem-list-v2&envId=dynamic-programming&difficulty=MEDIUM
/// </summary>
public class Problem
{
    /// <summary>
    /// https://www.youtube.com/watch?v=6aEyTjOwlJU
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int NumDecodings(string s)
    {
        var dp = new Dictionary<int, int>
        {
            [s.Length] = 1
        };

        for (var i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] is '0')
            {
                dp[i] = 0;
            }
            else
            {
                dp[i] = dp[i + 1];
            }

            if (i + 1 < s.Length && (s[i] is '1' || (s[i] is '2' && s[i + 1] <= '6')))
            {
                dp[i] += dp[i + 2];
            }
        }

        return dp[0];
    }
}