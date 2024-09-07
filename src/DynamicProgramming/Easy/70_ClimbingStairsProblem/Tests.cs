using FluentAssertions;

namespace DynamicProgramming.Easy._70_ClimbingStairsProblem;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return [2, 2];
        yield return [3, 3];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int input, int expected)
    {
        var actual = _sut.ClimbStairs(input);

        actual.Should().Be(expected);
    }
}