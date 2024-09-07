using System.Text.Json;
using FluentAssertions;

namespace ArrayProblems.Easy.SingleNumberProblem;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] { 2, 2, 1 },
            1
        ];
        yield return
        [
            new int[] { 4, 1, 2, 1, 2 },
            4
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] input, int expected)
    {
        var actual = _sut.SingleNumber(input);

        actual.Should().Be(expected);
    }
}