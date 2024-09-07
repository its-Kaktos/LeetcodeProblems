using System.Diagnostics;

namespace ArrayProblems.Medium.PermutationsProblem;

/// <summary>
/// https://leetcode.com/problems/permutations/?envType=problem-list-v2&envId=array
/// </summary>
public class Problem
{
    /// <summary>
    /// https://www.youtube.com/watch?v=FZe0UqISmUw
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public IList<IList<int>> Permute(Span<int> nums)
    {
        if (nums.Length == 0)
            return new List<IList<int>>
            {
                new List<int>()
            };

        var permutes = Permute(nums[1..]);

        var result = new List<IList<int>>();

        foreach (var perm in permutes)
        {
            for (var i = 0; i < perm.Count + 1; i++)
            {
                var permCopy = new List<int>(perm);
                permCopy.Insert(i, nums[0]);
                
                result.Add(permCopy);
            }
        }

        return result;
    }
    

    /*
  e = new List<IList<int>>
   {
        new List<int> { 1, 2, 3 },
        new List<int> { 1, 3, 2 },

        new List<int> { 2, 1, 3 },
        new List<int> { 3, 1, 2 },

        new List<int> { 2, 3, 1 },
        new List<int> { 3, 2, 1 },
   };

   [
   [1,2,3],

   [2,3,1],
   [3,1,2],

   [1,2,3],
   [2,3,1],
   [3,1,2]
   ]

   input = new[] { 1, 2, 3 }
 */
    public IList<IList<int>> Permute2(int[] nums)
    {
        if (nums.Length == 1)
            return new List<IList<int>>
            {
                new List<int> { nums[0] }
            };

        var result = new List<IList<int>>();
        var indicesOrg = new int[nums.Length];
        for (var i = 0; i < indicesOrg.Length; i++)
        {
            indicesOrg[i] = i - 1;
        }

        var indices = new List<int>(indicesOrg);
        for (var i = 0; i < nums.Length - 1; i++)
        {
            for (var j = 0; j < nums.Length; j++)
            {
                var current = new List<int>();
                for (var z = 0; z < nums.Length; z++)
                {
                    indices[z] += 1;
                    if (indices[z] >= nums.Length) indices[z] = 0;

                    current.Add(nums[indices[z]]);
                }

                result.Add(current);
            }

            indices = new List<int>(indicesOrg);
            for (var j = i + 1; j < nums.Length; j++)
            {
                indices[j] += 1;
            }
        }

        return result;
    }

    /*
      e = new List<IList<int>>
       {
            new List<int> { 1, 2, 3 },
            new List<int> { 1, 3, 2 },

            new List<int> { 2, 1, 3 },
            new List<int> { 3, 1, 2 },

            new List<int> { 2, 3, 1 },
            new List<int> { 3, 2, 1 },
       };

       a = [
       [1,3,2],
       [3,1,2],
       [3,2,1]
       ]

       input = new[] { 1, 2, 3 }
     */
    public IList<IList<int>> Permute1(int[] nums)
    {
        if (nums.Length == 1)
            return new List<IList<int>>
            {
                new List<int> { nums[0] }
            };

        var memo = new Dictionary<int, List<int>>();
        for (var i = 0; i < nums.Length; i++)
        {
            memo.Add(i, [i]);
        }

        var locked = new int[nums.Length];
        var result = new List<IList<int>>();

        var firstItemPreviousIndex = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = 0; j < locked.Length; j++)
            {
                locked[j] = 0;
            }

            (nums[firstItemPreviousIndex], nums[i]) = (nums[i], nums[firstItemPreviousIndex]);
            memo.TryGetValue(0, out var position);
            position!.Add(i);

            locked[i] = 1;

            result.Add(PermuteInternal1(new List<int>(nums), locked, memo));

            for (var j = i + 1; j < nums.Length; j++)
            {
                memo.TryGetValue(j, out position);
                if (position!.Exists(x => x == j)) continue;

                locked[j] = 1;
                result.Add(PermuteInternal1(new List<int>(nums), locked, memo));
            }

            firstItemPreviousIndex = i;
        }

        return result;
    }

    public IList<int> PermuteInternal1(List<int> nums, int[] locked, Dictionary<int, List<int>> memo)
    {
        var lockedCount = locked.Count(x => x == 1);
        if (lockedCount >= nums.Count - 1)
        {
            return nums;
        }

        for (var i = 0; i < locked.Length; i++)
        {
            if (locked[i] == 1) continue;

            for (var j = i + 1; j < locked.Length; j++)
            {
                if (locked[j] == 1) continue;

                memo.TryGetValue(i, out var position);
                if (position!.Exists(x => x == j)) continue;

                position!.Add(j);
                (nums[i], nums[j]) = (nums[j], nums[i]);

                locked[j] = 1;

                return PermuteInternal1(nums, locked, memo);
            }
        }

        return nums;
    }
}