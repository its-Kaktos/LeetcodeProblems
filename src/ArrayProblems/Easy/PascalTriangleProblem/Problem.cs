namespace ArrayProblems.Easy.PascalTriangleProblem;

/// <summary>
/// https://leetcode.com/problems/pascals-triangle/?envType=problem-list-v2&envId=array&difficulty=EASY
/// </summary>
public class Problem
{
    public IList<IList<int>> Generate(int numRows)
    {
        if (numRows == 1)
            return new List<IList<int>>()
            {
                new List<int> { 1 }
            };

        var result = new List<IList<int>>()
        {
            new List<int> { 1 },
            new List<int> { 1, 1 }
        };

        for (var i = 2; i < numRows; i++)
        {
            var current = new List<int>
            {
                1
            };

            var prev = result[^1];
            for (var j = 0; j < prev.Count - 1; j++)
            {
                current.Add(prev[j] + prev[j + 1]);
            }
            
            current.Add(1);
            result.Add(current);
        }

        return result;
    }
}