using FluentAssertions;

namespace ArrayProblems.Medium._57_InsertInterval;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[][]
            {
                [1, 3], [6, 9]
            },
            new int[] { 2, 5 },
            new int[][]
            {
                [1, 5], [6, 9]
            }
        ];
        yield return
        [
            new int[][]
            {
                [1, 2], [3, 5], [6, 7], [8, 10], [12, 16]
            },
            new int[] { 4, 8 },
            new int[][]
            {
                [1, 2], [3, 10], [12, 16]
            }
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[][] input, int[] newInterval, int[][] expected)
    {
        var actual = _sut.Insert(input, newInterval);

        actual.Should().BeEquivalentTo(expected);
    }
}