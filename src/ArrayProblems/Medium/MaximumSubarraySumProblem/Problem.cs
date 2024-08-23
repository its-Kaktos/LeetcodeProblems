namespace ArrayProblems.Medium.MaximumSubarraySumProblem;

public class Problem
{
    public long MaximumSubarraySum(int[] nums, int k)
    {
        var map = new Dictionary<int, List<int>>();
        var maxSum = long.MinValue;

        for (var i = 0; i < nums.Length; i++)
        {
            if (map.TryGetValue(nums[i], out var indices))
            {
                indices.Add(i);
                map[nums[i]] = indices;
            }
            else
            {
                map.TryAdd(nums[i], [i]);
            }

            if (map.TryGetValue(nums[i] - k, out var lowIndices))
            {
                var sum = 0L;
                foreach (var lowIndex in lowIndices)
                {
                    var from = Math.Min(lowIndex, i);
                    var to = Math.Max(lowIndex, i);

                    for (var j = from; j < to + 1; j++)
                    {
                        sum += nums[j];
                    }

                    maxSum = Math.Max(sum, maxSum);
                    sum = 0;
                }
            }


            if (map.TryGetValue(nums[i] + k, out var highIndices))
            {
                var sum = 0;
                foreach (var highIndex in highIndices)
                {
                    var from = Math.Min(highIndex, i);
                    var to = Math.Max(highIndex, i);

                    for (var j = from; j < to + 1; j++)
                    {
                        sum += nums[j];
                    }

                    maxSum = Math.Max(sum, maxSum);
                    sum = 0;
                }
            }
        }

        return maxSum == long.MinValue ? 0 : maxSum;
    }
}