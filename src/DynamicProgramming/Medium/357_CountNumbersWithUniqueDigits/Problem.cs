namespace DynamicProgramming.Medium._357_CountNumbersWithUniqueDigits;

/// <summary>
/// https://leetcode.com/problems/count-numbers-with-unique-digits/?envType=problem-list-v2&envId=dynamic-programming&difficulty=MEDIUM
/// </summary>
public class Problem
{
    public int CountNumbersWithUniqueDigits(int n)
    {
        // 100_000_000
        var result = 1;
        var countUpTo = (int)Math.Pow(10, n);
        var numbers = new int[9];
        Array.Fill(numbers, -1);

        for (var i = 1; i < countUpTo; i++)
        {
            var last = numbers[^1];
            last++;

            if (last == 10)
            {
                var position = numbers.Length - 1;
                var r = Increment(numbers, position);

                position -= r;
                
                for (var j = position; j < numbers.Length; j++)
                {
                }
            }
        }


        return result;
    }

    private bool Exists(int[] numbers, int value, int excludePosition)
    {
        for (var i = numbers.Length - 1; i >= 0; i--)
        {
            if (numbers[i] == -1) return true;
            if (i == excludePosition) continue;
            if (numbers[i] == value) return false;
        }

        return true;
    }

    private int Increment(int[] numbers, int position)
    {
        var count = 0;
        for (var i = position; i >= 0; i--)
        {
            if (numbers[i] == -1) numbers[i] = 0;

            var curr = numbers[i];
            curr++;
            if (curr < 10)
            {
                numbers[i] = curr;
                break;
            }

            numbers[i] = 0;
            count++;
        }

        return count;
    }

    /// <summary>
    /// This is my original WORKING answer which is SLOW
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int CountNumbersWithUniqueDigitsOrg(int n)
    {
        var memo = new HashSet<int>();
        var countUpTo = (int)Math.Pow(10, n);

        var result = 1;
        for (var i = 1; i < countUpTo; i++)
        {
            if (IsUnique(i, memo)) result++;
        }

        return result;
    }

    private bool IsUnique(int number, HashSet<int> memo)
    {
        if (number < 10) return true;
        if (memo.Contains(number / 10) || memo.Contains(number - 10) || memo.Contains(number / 2))
        {
            memo.Add(number);
            return false;
        }

        var set = new HashSet<int>();
        while (number > 0)
        {
            var digit = number % 10;
            number /= 10;

            if (!set.Add(digit))
            {
                memo.Add(number);
                return false;
            }
        }

        return true;
    }
}