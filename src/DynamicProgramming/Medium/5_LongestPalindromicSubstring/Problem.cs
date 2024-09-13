namespace DynamicProgramming.Medium._5_LongestPalindromicSubstring;

/// <summary>
/// https://leetcode.com/problems/longest-palindromic-substring/description/?envType=problem-list-v2&envId=dynamic-programming&difficulty=MEDIUM
/// </summary>
public class Problem
{
    /// <summary>
    /// https://www.youtube.com/watch?v=XYQecbcd6_c&ab_channel=NeetCode
    /// There are faster solutions for this that runs at O(N).
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string LongestPalindrome(string s)
    {
        if (s.Length == 1) return s;

        var bl = -1;
        var br = -1;
        var bLength = -1;

        for (var i = 0; i < s.Length; i++)
        {
            var left = i;
            var right = i;

            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                if (right - left + 1 > bLength)
                {
                    bl = left;
                    br = right;
                    bLength = right - left + 1;
                }

                left--;
                right++;
            }

            left = i;
            right = i + 1;

            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                if (right - left + 1 > bLength)
                {
                    bl = left;
                    br = right;
                    bLength = right - left + 1;
                }

                left--;
                right++;
            }
        }

        return s.Substring(bl, bLength);
    }
}