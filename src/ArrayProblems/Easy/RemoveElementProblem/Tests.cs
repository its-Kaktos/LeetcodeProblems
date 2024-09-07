using System.Text.Json;
using FluentAssertions;

namespace ArrayProblems.Easy.RemoveElementProblem;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] { 3, 2, 2, 3 },
            3,
            new int[] { 2, 2 },
            2
        ];
        yield return
        [
            new int[] { 0, 1, 2, 2, 3, 0, 4, 2 },
            2,
            new int[] { 0, 1, 4, 0, 3 },
            5
        ];
        yield return
        [
            new int[] { 0, 1, 2, 2, 3, 0, 4, 2 },
            2,
            new int[] { 0, 1, 4, 0, 3 },
            5
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] actual, int value, int[] expected, int expectedCount)
    {
        var actualCount = _sut.RemoveElement(actual, value);

        actualCount.Should().Be(expectedCount);

        foreach (var e in expected)
        {
            if (!actual.Any(a => e == a))
                Assert.Fail($"Expected to find {e} in {JsonSerializer.Serialize(actual)} but it was not found.");
        }
    }
}