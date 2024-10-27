using FluentAssertions;

namespace HashMapProblems.Easy._771_Jewels_and_Stones;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            "aA",
            "aAAbbbb",
            3
        ];
        yield return
        [
            "z",
            "ZZ",
            0
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(string jewels, string stones, int expected)
    {
        var actual = _sut.NumJewelsInStones(jewels, stones);

        actual.Should().Be(expected);
    }
}