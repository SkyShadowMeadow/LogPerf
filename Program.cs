using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using LogPerf;
using System.Threading;

BenchmarkRunner.Run<CsvBench>();

