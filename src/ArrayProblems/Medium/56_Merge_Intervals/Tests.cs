using FluentAssertions;

namespace ArrayProblems.Medium._56_Merge_Intervals;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[][]
            {
                new int[] { 1, 3 },
                new int[] { 2, 6 },
                new int[] { 8, 10 },
                new int[] { 15, 18 }
            },
            new int[][]
            {
                [1, 6],
                [8, 10],
                [15, 18]
            }
        ];
        yield return
        [
            new int[][]
            {
                [1, 4],
                [4, 5]
            },
            new int[][]
            {
                [1, 5]
            }
        ];
        yield return
        [
            new int[][]
            {
                [1, 4],
                [0, 4]
            },
            new int[][]
            {
                [0, 4]
            }
        ];
        yield return
        [
            new int[][]
            {
                [1, 4],
                [0, 1]
            },
            new int[][]
            {
                [0, 4]
            }
        ];
        yield return
        [
            new int[][]
            {
                [1, 4],
                [2, 3]
            },
            new int[][]
            {
                [1, 4]
            }
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[][] input, int[][] expected)
    {
        var actual = _sut.Merge(input);

        actual.Should().BeEquivalentTo(expected);
    }
}