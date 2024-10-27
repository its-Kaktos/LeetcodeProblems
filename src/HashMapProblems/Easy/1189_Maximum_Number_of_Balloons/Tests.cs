using FluentAssertions;

namespace HashMapProblems.Easy._1189_Maximum_Number_of_Balloons;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            "nlaebolko",
            1
        ];
        yield return
        [
            "loonbalxballpoon",
            2
        ];
        yield return
        [
            "leetcode",
            0
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(string input, int expected)
    {
        var actual = _sut.MaxNumberOfBalloons(input);

        actual.Should().Be(expected);
    }
}
