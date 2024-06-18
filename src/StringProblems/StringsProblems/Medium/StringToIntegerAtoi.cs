using System.Numerics;

namespace StringsProblems.Medium;

public class StringToIntegerAtoi
{
    /// <summary>
    /// https://leetcode.com/problems/string-to-integer-atoi/
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int MyAtoi(string s)
    {
        var isPositive = true;

        var index = 0;
        while (index < s.Length)
        {
            if (!char.IsWhiteSpace(s[index])) break;
            index++;
        }

        var isSignRead = false;
        while (index < s.Length)
        {
            if (s[index] == '-' || s[index] == '+')
            {
                if (isSignRead)
                {
                    return 0;
                }

                if (s[index] == '-')
                {
                    isPositive = false;
                }

                isSignRead = true;
                index++;
                continue;
            }

            var isNumber = char.IsNumber(s[index]);
            if (!isNumber) return 0;
            if (isNumber) break;

            index++;
        }

        var num = 0;
        while (index < s.Length && s[index] >= '0' && s[index] <= '9')
        {
            var digit = s[index++] - '0';
            if (num > (int.MaxValue - digit) / 10) return isPositive ? int.MaxValue : int.MinValue;

            num = num * 10 + digit;
        }

        return isPositive ? num : num * -1;
    }
}