using FluentAssertions;

namespace DynamicProgramming.Medium._22_GenerateParentheses;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            1,
            new string[] { "()" }
        ];
        yield return
        [
            3,
            new string[] { "((()))", "(()())", "(())()", "()(())", "()()()" }
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int input, string[] expected)
    {
        var actual = _sut.GenerateParenthesis(input);

        actual.Should().BeEquivalentTo(expected);
    }
}