namespace ArrayProblems.Medium._39_CombinationSum;

public class Problem
{
    // Input: candidates = [2,3,6,7], target = 7
    // Output: [[2,2,3],[7]]
    // Explanation:
    // 2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
    // 7 is a candidate, and 7 = 7.
    // These are the only two combinations.
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        var set = new HashSet<int>(candidates);

        var result = new List<IList<int>>();

        foreach (var candidate in candidates)
        {
            
        }

        return result;
    }
}