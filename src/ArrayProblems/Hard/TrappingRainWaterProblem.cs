namespace ArrayProblems.Hard;

public class TrappingRainWaterProblem
{
    public int Trap(int[] height)
    {
        var inverseMap = new List<int>();

        var max = height.Max();
        foreach (var h in height)
        {
            inverseMap.Add(max - h);
        }

        // in first and last position there cant be any water
        inverseMap[^1] = 0;
        // inverseMap[0] = 0;

        while (max > 0)
        {
            // start from ^2 to 1 in reverse.
            var s = inverseMap.Count - 2;
            for (var i = inverseMap.Count - 2; i >= 0; i--)
            {
                var isTherePillarOnRight = (inverseMap[i + 1] + height[i + 1]) >= (inverseMap[i] + height[i]);
                var isThereWaterOnRight = (inverseMap[i + 1] + height[i + 1]) >= (inverseMap[i] + height[i]);

                if (i == 0 && inverseMap[i] != height[i])
                {
                    isTherePillarOnRight = false;
                    isThereWaterOnRight = false;
                }

                if (!isTherePillarOnRight && !isThereWaterOnRight)
                {
                    var removeFrom = height[inverseMap.Count - 1];
                    for (var j = height.Length - 1; j >= i; j--)
                    {
                        if (removeFrom >= height[j])
                        {
                            removeFrom = j;
                        }
                    }

                    for (var j = removeFrom; j >= i; j--)
                    {
                        inverseMap[j] -= i;
                    }
                }
            }


            max--;
        }

        return inverseMap.Sum();
    }

    public int Trap1(int[] height)
    {
        var startFrom = 0;
        // Skip first 0 blocks
        for (var i = 0; i < height.Length; i++)
        {
            if (i == 0) continue;

            startFrom = i;
            break;
        }

        var curr = 0;
        var result = 0;

        var tmpResult = 0;
        for (var i = startFrom; i < height.Length; i++)
        {
            var jx = 0;
            curr = height[i];
            var biggerFound = false;

            for (var j = i + 1; j < height.Length; j++)
            {
                jx = j;
                if (height[j] >= curr)
                {
                    biggerFound = true;
                    result += tmpResult;
                    break;
                }

                var diff = curr - height[j];
                tmpResult += diff;
            }

            // if (i == height.Length - 1) break;
            if (biggerFound) i = jx - 1;

            tmpResult = 0;
        }

        return result;
    }
}