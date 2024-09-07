using System.Text.Json;
using FluentAssertions;

namespace ArrayProblems.Easy.PlusOneProblem;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] { 1, 2, 3 },
            new int[] { 1, 2, 4 }
        ];
        yield return
        [
            new int[] { 4, 3, 2, 1 },
            new int[] { 4, 3, 2, 2 }
        ];
        yield return
        [
            new int[] { 9 },
            new int[] { 1, 0 }
        ];
        yield return
        [
            new int[] { 1, 8, 9 },
            new int[] { 1, 9, 0 }
        ];
        yield return
        [
            new int[] { 1, 9, 9 },
            new int[] { 2, 0, 0 }
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] input, int[] expected)
    {
        var actual = _sut.PlusOne(input);

        actual.Should().Equal(expected);
    }
}