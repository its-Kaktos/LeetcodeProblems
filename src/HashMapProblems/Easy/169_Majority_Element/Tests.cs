using FluentAssertions;

namespace HashMapProblems.Easy._169_Majority_Element;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] { 3, 2, 3 },
            3,
        ];
        yield return
        [
            new int[] { 2, 2, 1, 1, 1, 2, 2 },
            2,
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] input, int expected)
    {
        var actual = _sut.MajorityElement(input);

        actual.Should().Be(expected);
    }
}