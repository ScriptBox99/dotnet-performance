// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using BenchmarkDotNet.Attributes;
using MicroBenchmarks;

namespace System.Tests
{
    [BenchmarkCategory(Categories.CoreFX)]
    public class Perf_Enum
    {
        [Flags]
        public enum Colors
        {
            Red = 0x1,
            Orange = 0x2,
            Yellow = 0x4,
            Green = 0x8,
            Blue = 0x10
        }

        [Benchmark]
        [Arguments("Red")]
        [Arguments("Red, Orange, Yellow, Green, Blue")]
        public Colors Parse(string text) => (Colors)Enum.Parse(typeof(Colors), text);

        [Benchmark]
        [Arguments("Red")]
        [Arguments("Red, Orange, Yellow, Green, Blue")]
        public bool TryParseGeneric(string text) => Enum.TryParse<Colors>(text, out _);

        private Colors _greenAndRed = Colors.Green | Colors.Red;

        [Benchmark]
        public bool HasFlag() => _greenAndRed.HasFlag(Colors.Green);
    }
}
