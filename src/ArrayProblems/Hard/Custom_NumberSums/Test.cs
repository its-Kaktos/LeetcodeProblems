using FluentAssertions;

namespace ArrayProblems.Hard.Custom_NumberSums;

public class Test
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[][]
            {
                [8, 3, 1, 5, 7, 2, 7],
                [4, 8, 8, 9, 1, 6, 6],
                [9, 1, 3, 9, 4, 2, 8],
                [4, 2, 1, 3, 9, 7, 4],
                [8, 9, 2, 8, 1, 9, 8],
                [8, 8, 5, 7, 7, 4, 5],
                [4, 1, 3, 8, 9, 5, 9]
            },
            new[] { 13, 27, 14, 37, 7, 7, 8 },
            new[] { 12, 17, 20, 10, 19, 20, 15 },
            new int[][]
            {
                [0, 0, 0, 1, 1, 0, 0],
                [0, 1, 0, 1, 0, 0, 0],
                [1, 0, 1, 0, 0, 0, 1],
                [0, 1, 1, 0, 0, 1, 0],
                [0, 1, 1, 1, 0, 0, 0],
                [0, 1, 1, 1, 0, 0, 0],
                [1, 0, 1, 1, 0, 0, 0]
            }
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[][] input, int[] horizontalSums, int[] verticalSums, int[][] expected)
    {
        var actual = _sut.SumNumbers(input, horizontalSums, verticalSums);

        actual.Should().BeEquivalentTo(expected);
    }
}