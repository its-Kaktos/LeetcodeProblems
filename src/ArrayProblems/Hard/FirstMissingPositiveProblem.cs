namespace ArrayProblems.Hard;

public class FirstMissingPositiveProblem
{
    public int FirstMissingPositive(int[] nums)
    {
        // var hashset = new HashSet<int>();
        // var max = 0;
        // for (int i = 0; i < nums.Length; i++)
        // {
        //     if (nums[i] > 0)
        //     {
        //         if (nums[i] > max)
        //         {
        //             max = nums[i];
        //         }
        //
        //         hashset.Add(nums[i]);
        //     }
        // }
        //
        // for (var i = 1; i < max; i++)
        // {
        //     if (!hashset.TryGetValue(i, out _)) return i;
        // }
        //
        // return max + 1;


        var n = nums.Length;
        
        var nonPosIdx = 0;
        
        for (var i = 0; i < n; i++)
        {
            if (nums[i] > 0) continue;

            (nums[i], nums[nonPosIdx]) = (nums[nonPosIdx], nums[i]);
            nonPosIdx++;
        }


        for (var i = nonPosIdx; i < n; i++)
        {
            var num = Math.Abs(nums[i]);
            if (num <= n - nonPosIdx && nums[num - 1 + nonPosIdx] > 0)
            {
                nums[num - 1 + nonPosIdx] *= -1;
            }
        }


        for (var i = nonPosIdx; i < n; i++)
        {
            if (nums[i] > 0)
            {
                return i - nonPosIdx + 1;
            }
        }

        return n - nonPosIdx + 1;
    }
}