using System.Numerics;

namespace StringsProblems.Medium;

public class StringToIntegerAtoi
{
    public int MyAtoi(string s)
    {
        var isSignRead = false;
        var isFirstCharacter = true;
        var isNumberBefore = false;
        var isPositive = true;
        var startIndex = -1;
        var stopIndex = -1;
        for (var i = 0; i < s.Length; i++)
        {
            if (char.IsWhiteSpace(s[i]))
            {
                if (isNumberBefore || isSignRead)
                {
                    stopIndex = i - 1;
                    break;
                }

                continue;
            }

            if (s[i] == '-' || s[i] == '+')
            {
                if (isNumberBefore)
                {
                    stopIndex = i - 1;
                    break;
                }

                if (isSignRead)
                {
                    break;
                }

                isSignRead = true;
                
                if (s[i] == '-')
                {
                    if (isNumberBefore)
                    {
                        stopIndex = i - 1;
                        break;
                    }

                    isPositive = false;
                }
                continue;
            }
            
            if (isFirstCharacter && (!isSignRead && s[i] != '+') && !char.IsNumber(s[i]))
            {
                return 0;
            }

            isFirstCharacter = false;

            if (!char.IsNumber(s[i]))
            {
                if (startIndex != -1 || isSignRead)
                {
                    stopIndex = i - 1;
                    break;
                }

                continue;
            }

            if (startIndex == -1)
            {
                startIndex = i;
                isNumberBefore = true;
            }
        }

        if (startIndex != -1 && stopIndex == -1) stopIndex = s.Length - 1;

        if (startIndex == -1 || stopIndex == -1) return 0;

        var resultAsLong = BigInteger.Parse(s.AsSpan(startIndex, stopIndex - startIndex + 1));

        if (resultAsLong > int.MaxValue)
        {
            return isPositive ? int.MaxValue : int.MinValue;
        }

        var result = (int)resultAsLong;

        return isPositive switch
        {
            true when int.IsNegative(result) => result * -1,
            false when int.IsPositive(result) => result * -1,
            _ => result
        };
    }
}