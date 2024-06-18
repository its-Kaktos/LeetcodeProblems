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
        var index = 0;
        for (var i = 0; i < p.Length; i++)
        {
            if(p[i] is '*' or '.') break;
            if(p[i] == '*' || p[i] == '.') break;
            
            index++;
        }

        return true;
    }
}