using FluentAssertions;

namespace ArrayProblems.Easy._2239_FindClosestNumberToZero;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] {-4,-2,1,4,8},
            1
        ];
        yield return
        [
            new int[] {2,-1,1},
            1
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] input, int expected)
    {
        var actual = _sut.FindClosestNumber(input);

        actual.Should().Be(expected);
    }
}