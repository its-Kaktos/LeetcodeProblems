using System.Reflection;
using System.Text.Json;
using FluentAssertions;

namespace ArrayProblems.Easy.RemoveDuplicatesFromSortedArrayProblem;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] { 1, 1, 2 },
            new int[] { 1, 2, int.MaxValue },
            2
        ];
        yield return
        [
            new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 },
            new int[] { 0, 1, 2, 3, 4, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue },
            5
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] actual, int[] expected, int expectedCount)
    {
        var actualCount = _sut.RemoveDuplicates(actual);

        actualCount.Should().Be(expectedCount);

        for (var i = 0; i < expectedCount; i++)
        {
            if(actual[i] == expected[i]) continue;
            
            Assert.Fail($"Expected {JsonSerializer.Serialize(expected)} but found {JsonSerializer.Serialize(actual)}");
        }
    }
}