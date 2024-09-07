namespace ArrayProblems.Easy.PlusOneProblem;

/// <summary>
/// https://leetcode.com/problems/plus-one/?envType=problem-list-v2&envId=array&difficulty=EASY
/// </summary>
public class Problem
{
    public int[] PlusOne(int[] digits)
    {
        var sum = digits[^1] + 1;
        if (sum < 10)
        {
            digits[^1] = sum;
            return digits;
        }

        digits[^1] = 0;

        var reminder = 1;
        var result = new List<int>(digits);
        for (var i = result.Count - 2; i >= 0; i--)
        {
            sum = result[i] + reminder;
            if (sum < 10)
            {
                reminder = 0;
                result[i] = sum;
                break;
            }

            result[i] = 0;
        }

        if (reminder > 0)
        {
            result.Insert(0, reminder);
        }

        return result.ToArray();
    }
}