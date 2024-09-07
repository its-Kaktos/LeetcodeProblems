using System.Collections;
using System.Reflection;

namespace ArrayProblems.Medium.JumpGame2Problem;

public class Problem
{
    private readonly Dictionary<int, int> _memo = new();

    /// <summary>
    /// https://leetcode.com/problems/jump-game-ii/description/?envType=problem-list-v2&envId=array
    /// https://www.youtube.com/watch?v=CsDI-yQuGeM
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int Jump(int[] nums)
    {
        var smallest = 0;
        var end = 0;
        var far = 0;
        
        for (var i = 0; i < nums.Length - 1; i++)
        {
            far = Math.Max(far, i + nums[i]);

            if (i == end)
            {
                smallest++;
                end = far;
            }
        }

        return smallest;
    }

    private int JumpInternal(int[] nums, List<List<int>> cache, int jumpTo, int jumps)
    {
        var possibleJumps = cache[jumpTo];
        for (var i = possibleJumps.Count - 1; i >= 0; i--)
        {
            if (possibleJumps[i] >= nums.Length - 1) return jumps + 1;
            if (nums[possibleJumps[i]] == 0) continue;

            var result = JumpInternal(nums, cache, possibleJumps[i], jumps + 1);
            if (result == -1) continue;

            return result;
        }

        return -1;
    }

    /*
       Input: nums = [2,3,1,1,4]
       Output: 2

       Input: nums = [2,3,0,1,4]
       Output: 2

       5, 6, 4, 4, 6, 9, 4, 4, 7, 4, 4, 8, 2, 6, 8, 1, 5, 9, 6, 5, 2, 7, 9, 7, 9, 6, 9, 4, 1, 6, 8, 8, 4, 4, 2, 0, 3, 8, 5
       e = 2
     */
    private int JumpInternal2(int[] nums, int currentIndex, int jumps)
    {
        var jumpTo = nums[currentIndex] + currentIndex;
        if (jumpTo >= nums.Length - 1) return jumps + 1;
        if (nums[currentIndex] == 0) return -1;

        var r = new List<int>();
        for (var i = jumpTo; i >= currentIndex + 1; i--)
        {
            if (_memo.TryGetValue(i, out var result) && result != -1)
            {
                r.Add(result);
            }

            result = JumpInternal2(nums, i, jumps + 1);

            _memo.TryAdd(i, result);
            if (result != -1) r.Add(result);
        }

        return r.Count > 0 ? r.Min() : -1;
    }

    /*
       Example 1:
       Input: nums = [2,3,1,1,4]
       Output: 2
       Explanation: The minimum number of jumps to reach the last index is 2. Jump 1 step from index 0 to 1, then 3 steps to the last index.

       Example 2:
       Input: nums = [2,3,0,1,4]
       Output: 2

       10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 1, 0
       e = 2
     */
    private int JumpInternalOrg(int[] nums, int currentIndex, int jumps)
    {
        var jumpTo = nums[currentIndex] + currentIndex;
        if (jumpTo >= nums.Length - 1) return jumps + 1;
        if (nums[currentIndex] == 0) return JumpInternalOrg(nums, currentIndex - 1, jumps);

        var maxIndex = currentIndex + 1;
        for (var i = currentIndex + 2; i <= jumpTo; i++)
        {
            if (nums[i] >= nums[maxIndex]) maxIndex = i;
        }

        return JumpInternalOrg(nums, maxIndex, jumps + 1);
    }
}