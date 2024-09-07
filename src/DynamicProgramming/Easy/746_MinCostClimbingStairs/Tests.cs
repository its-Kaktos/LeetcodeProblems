using FluentAssertions;

namespace DynamicProgramming.Easy._746_MinCostClimbingStairs;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] { 10, 15, 20 },
            15
        ];
        yield return
        [
            new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 },
            6
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] input, int expected)
    {
        var actual = _sut.MinCostClimbingStairs(input);

        actual.Should().Be(expected);
    }
}