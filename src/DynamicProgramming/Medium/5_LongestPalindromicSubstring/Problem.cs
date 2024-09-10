namespace DynamicProgramming.Medium._5_LongestPalindromicSubstring;

/// <summary>
/// https://leetcode.com/problems/longest-palindromic-substring/description/?envType=problem-list-v2&envId=dynamic-programming&difficulty=MEDIUM
/// </summary>
public class Problem
{
    // ["babad", "bab"];
    // ["cbbd", "bb"];
    public string LongestPalindrome(string s)
    {
        if (s.Length == 1) return s;

        var mid = s.Length / 2;
        var start = mid;
        var end = mid;

        while (start >= 0 && end <= s.Length - 1)
        {
            if (s[start] == s[end])
            {
                start--;
                end++;

                continue;
            }

            break;
        }

        while (start >= 0)
        {
            if (s[start] == s[end])
            {
                start--;

                continue;
            }

            break;
        }

        while (end >= s.Length - 1)
        {
            if (s[start] == s[end])
            {
                end++;

                continue;
            }

            break;
        }

        if (s[start + 1] == s[end - 1])
        {
            start++;
            end--;
        }
        else if (s[start + 1] == s[end])
        {
            start++;
        }
        else if (s[start] == s[end - 1])
        {
            end--;
        }

        var length = end - start;
        // length = Math.Max(length, 1);

        return s.Substring(start, length);
    }
}