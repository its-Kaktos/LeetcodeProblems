using System.Text.Json;
using FluentAssertions;

namespace ArrayProblems.Easy.ContainsDuplicateSecondProblem;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] { 1,2,3,1 },
            3,
            true
        ];
        yield return
        [
            new int[] { 1,0,1,1 },
            1,
            true
        ];
        yield return
        [
            new int[] { 1,2,3,1,2,3 },
            2,
            false
        ];
        yield return
        [
            new int[] { 99,99 },
            2,
            true
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] input, int k, bool expected)
    {
        var actual = _sut.ContainsNearbyDuplicate(input, k);

        actual.Should().Be(expected);
    }
}