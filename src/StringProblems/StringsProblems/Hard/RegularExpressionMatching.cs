using Microsoft.Win32.SafeHandles;

namespace StringsProblems.Hard;

public class RegularExpressionMatching
{
    /// <summary>
    /// https://leetcode.com/problems/regular-expression-matching/
    /// </summary>
    /// <param name="s"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public bool IsMatch(string s, string p)
    {
        var position = 0;
        var isLastWildCard = false;
        for (var i = 0; i < p.Length; i++)
        {
            var isAstrix = p[i] is '*';
            if (isAstrix)
            {
                isLastWildCard = true;
                continue;
            }

            var isDot = p[i] is '.';
            var isNextAstrix = i + 1 < p.Length && p[i + 1] is '*';
            if (position == s.Length)
            {
                if (isNextAstrix) continue;
                if (!isLastWildCard) return false;

                position--;
            }

            isLastWildCard = isDot || isAstrix;
            while (position < s.Length)
            {
                if (p[i] != '.' && p[i] != s[position]) break;

                position++;
                if (!isNextAstrix) break;
            }
        }

        if (position == s.Length) return true;
        if (position - 1 != s.Length) return false;

        return true;
    }
}