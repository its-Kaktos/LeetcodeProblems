// See https://aka.ms/new-console-template for more information

using StringsProblems.Medium;

Console.WriteLine("Hello, World!");


// new MultiplyStringsWrapper().Sum('5', '6');
// var result  =  new MultiplyStringsWrapper().Sum("66", "55");
// var result  =  new MultiplyStringsWrapper().Sum("666", "555");
// var result  =  new MultiplyStringsWrapper().Sum("9999", "9999");
// var result  =  new MultiplyStringsWrapper().Sum("5", "66");
// var result  =  new MultiplyStringsWrapper().Sum("99", "99");
// var result  =  new MultiplyStringsWrapper().Sum("6888", "123");

var result  =  new MultiplyStringsWrapper().Multiply("123", "456");
// var result  =  new MultiplyStringsWrapper().Multiply("123456789", "987654321");
// var result  =  new MultiplyStringsWrapper().Multiply("1234567", "7654321");


foreach (var se in result)
{
    Console.WriteLine(se);
}