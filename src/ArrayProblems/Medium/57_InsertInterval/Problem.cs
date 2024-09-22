namespace ArrayProblems.Medium._57_InsertInterval;

/// <summary>
/// https://leetcode.com/problems/insert-interval/?envType=problem-list-v2&envId=array&difficulty=MEDIUM
/// </summary>
public class Problem
{
    // new int[][]
    // {
    //     [1, 3], [6, 9]
    // },
    // new int[] { 2, 5 },
    // new int[][]
    // {
    //     [1, 5], [6, 9]
    // }
    // 
    //     [1, 3], [2, 5], [6, 9]
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var result = InsertWhereItBelong(intervals, newInterval);

        return MergeIntervals(result);
    }

    private int[][] MergeIntervals(List<int[]> intervals)
    {
        for (var i = 1; i < intervals.Count; i++)
        {
            if (intervals[i - 1][1] >= intervals[i][0])
            {
                intervals[i - 1][1] = intervals[i][1];
                intervals.RemoveAt(i);
            }
        }

        return intervals.ToArray();
    }

    private List<int[]> InsertWhereItBelong(int[][] intervals, int[] newInterval)
    {
        var result = new List<int[]>(intervals.Length + 1);
        result.AddRange(intervals);

        if (intervals[0][0] > newInterval[1])
        {
            result.Insert(0, newInterval);
            return result;
        }

        if (intervals[^1][1] < newInterval[0])
        {
            result.Add(newInterval);
            return result;
        }

        for (var i = 0; i < intervals.Length; i++)
        {
            if (newInterval[1] > intervals[i][0])
            {
                result.Insert(i + 1, newInterval);
                return result;
            }
        }

        return result;
    }
}