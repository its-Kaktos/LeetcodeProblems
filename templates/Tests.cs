using FluentAssertions;

namespace NAMESPACE_HERE;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] { -1, 2, 1, -4 },
            1,
            2
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] input, bool expected)
    {
        // TODO Test your method here
        var actual = _sut.Equals(input);

        actual.Should().Be(expected);
    }
}
