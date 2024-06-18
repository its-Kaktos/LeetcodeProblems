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
        for (var i = 0; i < p.Length; i++)
        {
            if (p[i] is '*') continue;

            if (position == s.Length)
            {
                if (p[i] != '.' || p[i] != '*')
                {
                    // TODO: when S is finished and last P was *, from end to start of P and S, start checking again.
                    if (i + 1 < p.Length && p[i + 1] == '*') continue;
                    
                    if (i - 1 >= 0 && p[i - 1] == '*')
                    {
                        if (i - 3 >= 0 && p[i - 3] == s[^1]) return false;
                        return s.EndsWith(p[i..]);
                    }

                    return false;
                }
            }

            var isNextAstrix = i + 1 < p.Length && p[i + 1] is '*';
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