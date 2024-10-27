namespace HashMapProblems.Medium._128_Longest_Consecutive_Sequence;

/// <summary>
///  https://leetcode.com/problems/longest-consecutive-sequence/description/
/// </summary>
public class Problem
{
    /// <summary>
    /// this is NOT my answer.
    /// Note: the question said to implement an answer
    ///     that runs in O(n).
    /// I've had a simple thought about this idea but
    /// in my mind it was O(n^2) because there was loop
    /// inside another loop.
    /// But turns out this actually runs in O(n) !!!
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int LongestConsecutive(int[] nums)
    {
        var set = new HashSet<int>(nums);

        var longest = 0;
        foreach (var num in set)
        {
            // If there is any number less than num
            // it means that num can not be start of
            // a sequence so skip it.
            if (set.Contains(num - 1)) continue;

            var length = 1;
            var nextNum = num + 1;
            while (set.Contains(nextNum))
            {
                length++;
                nextNum++;
            }

            longest = Math.Max(longest, length);
        }

        return longest;
    }
}