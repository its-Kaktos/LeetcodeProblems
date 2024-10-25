using System.Text;

namespace StringsProblems.Easy._13_Roman_To_Integer;

/// <summary>
/// https://leetcode.com/problems/roman-to-integer/description/
/// </summary>
public class Problem
{
    public int RomanToInt(string s)
    {
        var result = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var current = RomanToIntInternal(s[i]);

            if (i + 1 < s.Length)
            {
                var sub = Subtract(current, RomanToIntInternal(s[i + 1]));
                if (sub != current) i++;

                current = sub;
            }

            result += current;
        }

        return result;
    }

    private static int RomanToIntInternal(char c)
    {
        return c switch
        {
            'I' => 1,
            'V' => 5,
            'X' => 10,
            'L' => 50,
            'C' => 100,
            'D' => 500,
            'M' => 1000,
            _ => throw new Exception()
        };
    }

    private static int Subtract(int a, int b)
    {
        return a switch
        {
            1 when b is 5 or 10 => b - a,
            10 when b is 50 or 100 => b - a,
            100 when b is 500 or 1000 => b - a,
            _ => a
        };
    }
}