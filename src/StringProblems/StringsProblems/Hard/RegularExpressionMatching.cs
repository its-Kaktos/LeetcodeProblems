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
        var pI = 0;
        var sI = 0;
        while (pI < p.Length)
        {
            if (pI + 1 < p.Length && p[pI + 1] is '*')
            {
                pI++;
                continue;
            }

            if (p[pI] is '*')
            {
                if (sI >= s.Length && pI == p.Length - 1) return true;

                if (pI < p.Length - 1 && sI >= s.Length)
                {
                    if (pI + 2 < p.Length && p[pI + 2] is '*')
                    {
                        pI += 2;
                        continue;
                    }

                    pI++;
                    sI--;
                    continue;
                }

                if (p[pI - 1] is '.' || p[pI - 1] == s[sI])
                {
                    sI++;
                    continue;
                }
                
                pI++;
                if (pI >= p.Length && pI - 3 >= 0 && p[pI - 3] == s[sI]) return true;
                if (pI == p.Length - 1 && p[pI] is not '.')
                {
                    var lastCharacter = GetLastCharacter(pI);

                    if ((lastCharacter is '.' || lastCharacter == s[sI]) && (sI - 1 <= 0 || s[sI - 1] != lastCharacter) &&
                        !AnySpecificCharAstrixExistsBetweenExclusive(pI, p[pI])) return false;
                }
                continue;
            }

            if (sI >= s.Length) return false;

            if (p[pI] is '.' || s[sI] == p[pI])
            {
                sI++;
                pI++;

                if (sI >= s.Length && pI >= p.Length) return true;
                if (pI <= p.Length - 1 && sI >= s.Length  && p[pI] is not '.' && p[pI] != s[sI - 1]) sI--;
                continue;
            }
            
            pI++;
        }

        return false;

        char GetLastCharacter(int before)
        {
            for (var r = before - 1; r >= 0; r--)
            {
                if (p[r] is '*')
                {
                    r--;
                    continue;
                }

                return p[r];
            }

            return ' ';
        }

        bool AnySpecificCharAstrixExistsBetweenExclusive(int end, char c)
        {
            for (var i = end - 1; i >= 0; i--)
            {
                if (p[i] is '*' && i - 1 != 0 && p[i - 1] == c) return true;
            }

            return false;
        }
    }
}