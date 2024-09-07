namespace DynamicProgramming.Easy._121_BestTimeToBuyAndSellStock;

/// <summary>
/// https://leetcode.com/problems/best-time-to-buy-and-sell-stock?envType=problem-list-v2&envId=dynamic-programming&difficulty=EASY
/// </summary>
public class Problem
{
    public int MaxProfit(int[] prices)
    {
        if (prices.Length == 1) return 0;

        var profit = 0;
        var low = 0;
        var high = 1;
        while (high < prices.Length)
        {
            if (prices[low] > prices[high])
            {
                low = high;
                high++;
                continue;
            }

            profit = Math.Max(profit, prices[high] - prices[low]);
            high++;
        }

        return profit;
    }
    
    /// <summary>
    /// This is my original WORKING answer but its SLOW.
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public int MaxProfitOrg(int[] prices)
    {
        var max = 0;
        for (var i = 0; i < prices.Length; i++)
        {
            for (var j = i + 1; j < prices.Length; j++)
            {
                if(prices[j] <= prices[i]) continue;

                var diff = prices[j] - prices[i];
                if (diff > max) max = diff;
            }
        }

        return max;
    }
}