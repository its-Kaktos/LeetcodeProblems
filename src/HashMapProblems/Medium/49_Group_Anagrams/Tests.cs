using FluentAssertions;

namespace HashMapProblems.Medium._49_Group_Anagrams;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new string[] { "eat", "tea", "tan", "ate", "nat", "bat" },
            new List<IList<string>>()
            {
                new List<string> { "bat" },
                new List<string> { "nat", "tan" },
                new List<string> { "ate", "eat", "tea" }
            }
        ];
        yield return
        [
            new string[] { "" },
            new List<IList<string>>()
            {
                new List<string> { "" },
            }
        ];
        yield return
        [
            new string[] { "a" },
            new List<IList<string>>()
            {
                new List<string> { "a" },
            }
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(string[] input, IList<IList<string>> expected)
    {
        var actual = _sut.GroupAnagrams(input);

        actual.Should().BeEquivalentTo(expected);
    }
}