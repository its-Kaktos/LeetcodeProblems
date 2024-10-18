using FluentAssertions;

namespace ArrayProblems.Medium._238_ProductOfArrayExceptSelf;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[]
            {
                1, 2, 3, 4
            },
            new int[]
            {
                24, 12, 8, 6
            }
        ];
        yield return
        [
            new int[]
            {
                -1, 1, 0, -3, 3
            },
            new int[]
            {
                0, 0, 9, 0, 0
            }
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] input, int[] expected)
    {
        var actual = _sut.ProductExceptSelf(input);

        actual.Should().BeEquivalentTo(expected);
    }
}