using FluentAssertions;

namespace ArrayProblems.Medium._54_SpiralMatrix;

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
            new List<int>
            {
                1, 2, 3, 6, 9, 8, 7, 4, 5
            }
        ];
        yield return
        [
            new int[][]
            {
                [1, 2, 3, 4],
                [5, 6, 7, 8],
                [9, 10, 11, 12]
            },
            new List<int>
            {
                1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7
            }
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[][] input, IList<int> expected)
    {
        var actual = _sut.SpiralOrder(input);

        actual.Should().BeEquivalentTo(expected);
    }
}