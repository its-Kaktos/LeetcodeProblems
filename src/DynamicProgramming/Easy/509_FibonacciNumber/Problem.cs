namespace DynamicProgramming.Easy._509_FibonacciNumber;

/// <summary>
/// https://leetcode.com/problems/fibonacci-number/description/?envType=problem-list-v2&envId=dynamic-programming&difficulty=EASY
/// </summary>
public class Problem
{
    public int Fib(int n)
    {
        if (n == 0) return 0;

        var first = 0;
        var second = 1;

        while (n >= 2)
        {
            var temp = first + second;
            first = second;
            second = temp;

            n--;
        }

        return second;
    }

    /// <summary>
    /// This is my original WORKING answer.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int FibOrg(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;

        return FibOrg(n - 1) + FibOrg(n - 2);
    }
}