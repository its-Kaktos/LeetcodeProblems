// using FluentAssertions;
// using StringsProblems.Medium;
//
// namespace StringsProblems.UnitTests.Medium;
//
// public class StringToIntegerAtoiTests
// {
//     private readonly StringToIntegerAtoi _sut = new();
//
//     public static IEnumerable<object[]> Data_Test()
//     {
//         yield return new object[] { "42", 42 };
//         yield return new object[] {"42", 42};
//         yield return new object[] {"   -042", -42};
//         yield return new object[] {"   +042", 42};
//         yield return new object[] {"   +-042", 0};
//         yield return new object[] {"   +-042", 0};
//         yield return new object[] {"1337c0d32", 1337};
//         yield return new object[] {"swd1337c0d32", 0};
//         yield return new object[] {"0-1", 0};
//         yield return new object[] {"words and 987", 0};
//         yield return new object[] {"20000000000000", int.MaxValue};
//         yield return new object[] {"-20000000000000", int.MinValue};
//         yield return new object[] {"+", 0};
//         yield return new object[] {"-", 0};
//         yield return new object[] {"-+", 0};
//         yield return new object[] {"w-+", 0};
//     }
//
//     [Theory]
//     [MemberData(nameof(Data_Test))]
//     public void Test(string input, int expected)
//     {
//         var actual = _sut.MyAtoi(input);
//
//         actual.Should().Be(expected);
//     }
// }