// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using FastestWayToWorkWithJsonBenhmark;

Console.WriteLine("Testing differentes libraries to serialize and deserialize json 🚀");
BenchmarkRunner.Run<JsonBenchmark>();
