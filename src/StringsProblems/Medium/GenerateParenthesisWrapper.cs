using System.Text;

namespace StringsProblems.Medium;

/// <summary>
/// https://leetcode.com/problems/generate-parentheses/
/// </summary>
public class GenerateParenthesisWrapper
{
    public IList<string> GenerateParenthesis(int n)
    {
        const string pair = "()";
        var def = "";
        for (var i = 0; i < n; i++)
        {
            def += pair;
        }

        var result = new HashSet<string>
        {
            def
        };

        if (n <= 1) return result.ToList();

        var sa = def.ToArray();
        for (var i = def.Length - 3; i >= 1; i--)
        {
            (sa[i], sa[i + 1]) = (sa[i + 1], sa[i]);

            result.Add(new string(sa));
        }

        sa = def.ToArray();
        for (int i = 1; i < (def.Length - 1) / 2 ; i++)
        {
            (sa[i], sa[i + 1]) = (sa[i + 1], sa[i]);

            result.Add(new string(sa));
        }

        result.Add(new string('(', n) + new string(')', n));

        return result.ToList();
    }
}