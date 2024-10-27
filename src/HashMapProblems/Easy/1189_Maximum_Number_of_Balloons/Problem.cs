namespace HashMapProblems.Easy._1189_Maximum_Number_of_Balloons;

/// <summary>
///  https://leetcode.com/problems/maximum-number-of-balloons/description/
/// </summary>
public class Problem
{
    // I've implemented both methods.
    public int MaxNumberOfBalloons(string text)
    {
        var frequencyMap = new int[]
        {
            0, // b
            0, // a
            0, // l
            0, // o
            0, // n
        };

        foreach (var c in text)
        {
            switch (c)
            {
                case 'b':
                    frequencyMap[0] += 1;
                    break;
                case 'a':
                    frequencyMap[1] += 1;
                    break;
                case 'l':
                    frequencyMap[2] += 1;
                    break;
                case 'o':
                    frequencyMap[3] += 1;
                    break;
                case 'n':
                    frequencyMap[4] += 1;
                    break;
            }
        }

        frequencyMap[3] /= 2;
        frequencyMap[2] /= 2;

        return frequencyMap.Min();
    }

    public int MaxNumberOfBalloons_firstWay(string text)
    {
        var frequencyMap = new Dictionary<char, int>()
        {
            { 'b', 0 },
            { 'a', 0 },
            { 'l', 0 },
            { 'o', 0 },
            { 'n', 0 },
        };

        foreach (var c in text)
        {
            if (c is 'b' or 'a' or 'l' or 'o' or 'n')
            {
                frequencyMap[c] = ++frequencyMap[c];
            }
        }

        frequencyMap['l'] /= 2;
        frequencyMap['o'] /= 2;

        return frequencyMap.Values.Min();
    }
}