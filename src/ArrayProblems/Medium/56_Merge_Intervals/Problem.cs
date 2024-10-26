namespace ArrayProblems.Medium._56_Merge_Intervals;

/// <summary>
///  https://leetcode.com/problems/merge-intervals/description/
/// </summary>
public class Problem
{
    public int[][] Merge(int[][] intervals)
    {
        if (intervals.Length == 1) return intervals;
        Array.Sort(intervals, (ints, ints1) => ints[0].CompareTo(ints1[0]));
        
        var output = new List<int[]> { intervals[0] };

        for (var i = 1; i < intervals.Length; i++)
        {
            var curr = intervals[i];
            var prev = output[^1];
            if (prev[1] >= curr[0])
            {
                prev[0] = Math.Min(prev[0], curr[0]);
                prev[1] = Math.Max(prev[1], curr[1]);
                continue;
            }

            output.Add(curr);
        }

        return output.ToArray();
    }
}