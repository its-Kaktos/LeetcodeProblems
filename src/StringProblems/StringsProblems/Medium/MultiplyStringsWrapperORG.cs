namespace StringsProblems.Medium;

/// <summary>
/// https://leetcode.com/problems/multiply-strings/
/// </summary>
public class MultiplyStringsWrapperORG
{
    private static readonly List<char> MapChar = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

    public string Multiply(string num1, string num2)
    {
        const char zero = '0'; // 48
        const char nine = '9'; // 57

        var i = 0;
        var result = new List<char>() { '0' };
        while (i.ToString() != num2)
        {
            result = Sum(new string(result.ToArray()), num1);
            i++;
        }

        return new string(result.ToArray());
    }

    public List<char> Sum(string num1, string num2)
    {
        var output = new List<char>();
        var (smallerLength, greaterLength) = num1.Length < num2.Length
            ? (num1.ToList(), num2.ToList())
            : (num2.ToList(), num1.ToList());

        for (int j = smallerLength.Count; j < greaterLength.Count; j++)
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
            
            for (int j = 0; j < count; j++)
            {
                temp.Add('0');
            }
            
            for (int j = output.Count; j < temp.Count; j++)
            {
                output.Insert(0, '0');
            }
            
            char? r = null;
            for (int j = 1; j <= temp.Count; j++)
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
            
            if(r is not null) output.Insert(0, r.Value);
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