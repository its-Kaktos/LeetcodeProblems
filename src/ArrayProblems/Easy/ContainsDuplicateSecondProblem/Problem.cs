namespace ArrayProblems.Easy.ContainsDuplicateSecondProblem;

/// <summary>
/// https://leetcode.com/problems/contains-duplicate-ii/description/?envType=problem-list-v2&envId=array&difficulty=EASY
/// </summary>
public class Problem
{
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        var cache = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (cache.TryGetValue(nums[i], out var index))
            {
                if (Math.Abs(i - index) <= k) return true;

                cache[nums[i]] = i;
                continue;
            }
            
            cache.Add(nums[i], i);
        }

        return false;
    }
    
    /// <summary>
    /// This is my original WORKING answer. didnt want to compliate things.
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public bool ContainsNearbyDuplicateOrg(int[] nums, int k)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            var start = Math.Max(0, i - k);
            var end = Math.Min(nums.Length, i + k + 1);
            for (var j = start; j < end; j++)
            {
                if(j == i || nums[i] != nums[j]) continue;
                if (Math.Abs(i - j) <= k) return true;
            }
        }

        return false;
    }
}