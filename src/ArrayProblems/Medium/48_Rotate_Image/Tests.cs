using FluentAssertions;

namespace ArrayProblems.Medium._48_Rotate_Image;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[][]
            {
                [1, 2, 3],
                [4, 5, 6],
                [7, 8, 9]
            },
            new int[][]
            {
                [7, 4, 1],
                [8, 5, 2],
                [9, 6, 3]
            }
        ];
        yield return
        [
            new int[][]
            {
                [5, 1, 9, 11],
                [2, 4, 8, 10],
                [13, 3, 6, 7],
                [15, 14, 12, 16]
            },
            new int[][]
            {
                [15, 13, 2, 5],
                [14, 3, 4, 1],
                [12, 6, 8, 9],
                [16, 7, 10, 11]
            }
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[][] input, int[][] expected)
    {
        _sut.Rotate(input);

        input.Should().BeEquivalentTo(expected);
    }
}