using System.Text;

namespace StringsProblems.Medium;

/// <summary>
/// https://leetcode.com/problems/multiply-strings/
/// </summary>
public class MultiplyStringsWrapper
{
    private static readonly List<char> MapChar = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

    /// <summary>
    /// https://leetcode.com/problems/multiply-strings/solutions/3589682/c-solution-which-beats-91-42-others-in-memory/
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public string Multiply(string num1, string num2)
    {
        var length1 = num1.Length;
        var length2 = num2.Length;
        var result = new int[length1 + length2];

        for (var i = length1 - 1; i >= 0; i--)
        {
            for (var j = length2 - 1; j >= 0; j--)
            {
                var digit1 = num1[i] - '0';
                var digit2 = num2[j] - '0';
                var product = digit1 * digit2;
                var sum = result[i + j + 1] + product;

                result[i + j + 1] = sum % 10;
                result[i + j] += sum / 10;
            }
        }

        var sb = new StringBuilder();
        foreach (var digit in result)
        {
            sb.Append(digit);
        }

        // Remove leading zeros if any
        while (sb.Length > 1 && sb[0] == '0')
        {
            sb.Remove(0, 1);
        }

        return sb.ToString();
    }

    public string Multiply2(string num1, string num2)
    {
        const char zero = '0'; // 48
        const char nine = '9'; // 57

        var i = 0;
        var num2Reversed = num2.Reverse().ToArray();
        var result = new List<char> { '0' };
        while (!GetDigits(i).SequenceEqual(num2Reversed))
        {
            result = Sum(new string(result.ToArray()), num1);
            i++;
        }

        return new string(result.ToArray());
    }

    public static IEnumerable<char> GetDigits(int source)
    {
        while (source > 0)
        {
            var digit = source % 10;
            source /= 10;
            yield return MapChar[digit];
        }
    }

    public List<char> Sum(string num1, string num2)
    {
        var output = new List<char>();
        var (smallerLength, greaterLength) = num1.Length < num2.Length
            ? (num1.ToList(), num2.ToList())
            : (num2.ToList(), num1.ToList());

        for (var j = smallerLength.Count; j < greaterLength.Count; j++)
        {
            smallerLength.Insert(0, '0');
        }

        var count = -1;
        for (var i = smallerLength.Count - 1; i >= 0; i--)
        {
            count++;

            var temp = new List<char>();
            var (reminder, result) = Sum(smallerLength[i], greaterLength[i]);

            temp.Insert(0, result);

            if (reminder is not null) temp.Insert(0, reminder.Value);

            for (var j = 0; j < count; j++)
            {
                temp.Add('0');
            }

            for (var j = output.Count; j < temp.Count; j++)
            {
                output.Insert(0, '0');
            }

            char? r = null;
            for (var j = 1; j <= temp.Count; j++)
            {
                if (temp[^j] is '0') continue;

                if (j > output.Count)
                {
                    if (r is not null)
                    {
                        var tr = r;
                        var rs = Sum(temp[^j], tr.Value);

                        r = rs.reminder;
                        output.Insert(0, rs.result);
                        continue;
                    }

                    output.Insert(0, temp[^j]);
                    continue;
                }

                var sum = Sum(output[^j], temp[^j]);
                if (r is not null)
                {
                    var tr = r;
                    var rs = Sum(sum.result, tr.Value);

                    r = rs.reminder;
                    output[^j] = rs.result;
                    continue;
                }

                if (sum.reminder is not null)
                {
                    r = sum.reminder;
                }

                output[^j] = sum.result;
            }

            if (r is not null) output.Insert(0, r.Value);
        }

        return output;
    }

    private (char? reminder, char result) Sum(char f, char s)
    {
        const char zero = '0'; // 48
        const char nine = '9'; // 57

        var sum = f + s;
        var resultChar = sum - zero;
        if (resultChar <= nine) return (null, (char)resultChar);

        var reminder = resultChar - nine;
        return ('1', MapChar[reminder - 1]);
    }
}