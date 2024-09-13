using FluentAssertions;

namespace DynamicProgramming.Medium._368_LargestDivisibleSubset;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] { 1, 2, 3 },
            new int[] { 1, 2 }
        ];
        yield return
        [
            new int[] { 1, 2, 4, 8 },
            new int[] { 1, 2, 4, 8 }
        ];
        yield return
        [
            new int[] { 3, 4, 16, 8 },
            new int[] { 4, 8, 16 }
        ];
        yield return
        [
            new int[] { 2, 3, 4, 8 },
            new int[] { 2, 4, 8 }
        ];
        yield return
        [
            new int[] { 3, 17 },
            new int[] { 3 } // the result can also be 17 as well.
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] input, int[] expected)
    {
        var actual = _sut.LargestDivisibleSubset(input);

        actual.Should().BeEquivalentTo(expected);
    }
}