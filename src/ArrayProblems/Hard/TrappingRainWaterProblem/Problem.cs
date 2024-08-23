namespace ArrayProblems.Hard.TrappingRainWaterProblem;

/// <summary>
/// https://leetcode.com/problems/trapping-rain-water/
/// </summary>
public class Problem
{
    public int Trap(int[] height)
    {
        var lo = 0;
        var hi = height.Length - 1;
        var maxLeft = height[lo];
        var maxRight = height[hi];

        var count = 0;
        while (lo < hi)
        {
            if (maxLeft < maxRight)
            {
                lo++;
                maxLeft = Math.Max(maxLeft, height[lo]);
                count += maxLeft - height[lo];

                continue;
            }

            hi--;
            maxRight = Math.Max(maxRight, height[hi]);
            count += maxRight - height[hi];
        }

        return count;
    }

    // Below are my attempts
    public int Trap3(int[] height)
    {
        var supportIndex = FindSupports1(height, 0);

        var total = 0;
        foreach (var (lsi, rsi) in supportIndex)
        {
            total += WaterHeight1(height, lsi, rsi);
        }

        return total;
    }

    private int WaterHeight1(int[] height, int lsi, int rsi)
    {
        var minHeight = Math.Min(height[lsi], height[rsi]);
        if (minHeight == 0) return 0;

        var totalSection = 0;
        for (var i = lsi + 1; i < rsi; i++)
        {
            var waterHeight = minHeight - height[i];
            totalSection += Math.Max(0, waterHeight);
        }

        return totalSection;
    }

    private List<(int lsi, int rsi)> FindSupports1(int[] height, int startFrom)
    {
        var supportIndex = new List<(int lsi, int rsi)>();
        if (height.Length < 3 || height.Length - startFrom <= 2) return supportIndex;

        if (startFrom == height.Length - 3)
        {
            if (height[startFrom + 1] >= height[startFrom] ||
                height[startFrom + 1] >= height[startFrom + 2])
            {
                return supportIndex;
            }

            supportIndex.Add((startFrom, height.Length - 1));
            return supportIndex;
        }

        var lsi = -1;
        var prsi = -1;
        for (var i = startFrom; i < height.Length; i++)
        {
            if (lsi == -1)
            {
                if (height[i] > 0) lsi = i;

                continue;
            }

            if (prsi == -1) prsi = i;

            prsi = height[i] > height[prsi] ? i : prsi;
            if (height[lsi] > height[i]) continue;

            if (i - lsi >= 2) supportIndex.Add((lsi, i));
            if (i + 1 < height.Length)
            {
                lsi = i;
                continue;
            }

            lsi = -1;
            prsi = -1;
        }

        if (lsi != -1)
        {
            // if (prsi != -1)
            // {
            //     supportIndex.Add((lsi, prsi));
            // }

            // if (height[lsi] <= height[^1] || lsi == height.Length - 3)
            if (WaterHeight1(height, lsi, height.Length - 1) > 0 || height[lsi] <= height[^1] || lsi == height.Length - 3)
            {
                supportIndex.Add((lsi, height.Length - 1));
                return supportIndex;
            }

            supportIndex.AddRange(
                FindSupports1(height, lsi + 1));
        }

        return supportIndex;
    }

    public int Trap2(int[] height)
    {
        return TrapInternal2(height, 1, 0);
    }

    public int TrapInternal2(int[] height, int startFrom, int decreaseWaterHeight)
    {
        var total = 0;
        var leftSupportIndex = 0;
        var leftSupportHeight = 0;
        var sectionCount = 0;
        for (var i = startFrom; i < height.Length - 1; i++)
        {
            var waterHeight = leftSupportHeight != 0 ? leftSupportHeight - height[i] : height[i - 1] - height[i];
            waterHeight -= decreaseWaterHeight;
            if (waterHeight > 0 && leftSupportHeight == 0)
            {
                leftSupportIndex = i - 1;
                leftSupportHeight = height[i - 1];
            }

            if (waterHeight <= 0 && height[i] >= leftSupportHeight)
            {
                total += sectionCount;
                leftSupportIndex = 0;
                leftSupportHeight = 0;
                sectionCount = 0;
                continue;
            }

            sectionCount += waterHeight;
        }

        if (leftSupportHeight != 0) total += sectionCount;

        if (height[^1] < leftSupportHeight && leftSupportIndex != height.Length - 3)
        {
            total -= sectionCount;

            total += TrapInternal2(height, leftSupportIndex + 1, decreaseWaterHeight + 1);
        }

        return total;
    }

    public int Trap1(int[] height)
    {
        var max = height.Max();
        var total = 0;
        var iterationCount = 0;

        while (iterationCount <= max - 1)
        {
            for (var i = 1; i < height.Length - 1; i++)
            {
                var waterHeight = max - height[i] - iterationCount;
                if (waterHeight <= 0) continue;

                var heightWithWater = height[i] + waterHeight;

                var isSupportOnLeftNode = height[i - 1] >= heightWithWater;
                if (!isSupportOnLeftNode) continue;

                var count = 0;
                for (var j = i; j < height.Length - 1; j++)
                {
                    count++;

                    waterHeight = max - height[j] - iterationCount;
                    heightWithWater = height[j] + waterHeight;
                    var isSupportOnRight = height[j + 1] >= heightWithWater;
                    if (!isSupportOnRight) continue;

                    i = j;
                    break;
                }

                var isRightSupport = height[i + 1] >= heightWithWater;
                if (i + 1 <= height.Length - 1 && !isRightSupport) count = 0;

                total += count;
            }

            iterationCount++;
        }

        return total;
    }
}