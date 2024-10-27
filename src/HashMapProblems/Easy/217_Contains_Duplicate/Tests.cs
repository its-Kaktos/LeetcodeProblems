using FluentAssertions;

namespace HashMapProblems.Easy._217_Contains_Duplicate;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] {1, 2, 3, 1},
            true
        ];
        yield return
        [
            new int[] {1,2,3,4},
            false
        ];
        yield return
        [
            new int[] {1,1,1,3,3,4,3,2,4,2},
            true
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] input, bool expected)
    {
        var actual = _sut.ContainsDuplicate(input);

        actual.Should().Be(expected);
    }
}