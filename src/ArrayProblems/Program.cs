// See https://aka.ms/new-console-template for more information

using ArrayProblems.Easy;
using ArrayProblems.Hard;

// var nums = Enumerable.Range(0, 100).ToList();
var nums = new[] { 4, 2, 0, 3, 2, 5 };

var sut = new TrappingRainWaterProblem().Trap(nums);

Console.WriteLine(sut);

Console.WriteLine("Hello, World!");