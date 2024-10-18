using FluentAssertions;

namespace ArrayProblems.Medium._39_CombinationSum;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] { 2, 3, 6, 7 },
            7,
            new List<IList<int>>
            {
                new List<int>
                {
                    2, 2, 3
                },
                new List<int>
                {
                    7
                }
            }
        ];
        yield return
        [
            new int[] { 2, 3, 5 },
            8,
            new List<IList<int>>
            {
                new List<int>
                {
                    2, 2, 2, 2
                },
                new List<int>
                {
                    2, 3, 3
                },
                new List<int>
                {
                    3, 5
                }
            }
        ];
        yield return
        [
            new int[] { 2 },
            0,
            new List<IList<int>>()
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] input, int target, int[] expected)
    {
        var actual = _sut.CombinationSum(input, target);

        actual.Should().BeEquivalentTo(expected);
    }
}