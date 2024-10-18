using FluentAssertions;

namespace StringsProblems.Easy._1768_Merge_Strings_Alternately;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            "abc",
            "pqr",
            "apbqcr"
        ];
        yield return
        [
            "ab",
            "pqrs",
            "apbqrs"
        ];
        yield return
        [
            "abcd",
            "pq",
            "apbqcd"
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(string word1, string word2, string expected)
    {
        var actual = _sut.MergeAlternately(word1, word2);

        actual.Should().Be(expected);
    }
}