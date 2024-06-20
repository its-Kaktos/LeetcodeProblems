namespace StringsProblems.Hard;

public class RegularExpressionMatching
{
    private bool?[,] _cacheMemo;

    /// <summary>
    /// https://leetcode.com/problems/regular-expression-matching/
    /// Code from : https://www.youtube.com/watch?v=HAA8mgxlov8&amp;ab_channel=NeetCode - https://leetcode.com/problems/regular-expression-matching/editorial/
    /// </summary>
    /// <param name="s"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public bool IsMatch(string s, string p)
    {
        _cacheMemo = new bool?[s.Length + 1, p.Length + 1];
        return DepthFirstSearch(0, 0, s, p);
    }

    private bool DepthFirstSearch(int i, int j, string text, string pattern)
    {
        if (_cacheMemo[i, j] != null) return _cacheMemo[i, j]!.Value;

        bool result;
        if (j == pattern.Length)
        {
            result = i == text.Length;
            _cacheMemo[i, j] = result;
            return result;
        }

        var isMatch = i < text.Length && (pattern[j] == text[i] || pattern[j] == '.');
        if (j + 1 < pattern.Length && pattern[j + 1] == '*')
        {
            result = DepthFirstSearch(i, j + 2, text, pattern) || // dont use *
                     (isMatch && DepthFirstSearch(i + 1, j, text, pattern)); // use *
            _cacheMemo[i, j] = result;
            return result;
        }

        result = isMatch && DepthFirstSearch(i + 1, j + 1, text, pattern);
        _cacheMemo[i, j] = result;
        return result;
    }
}