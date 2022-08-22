// Copyright (c) Imazen LLC.
// No part of this project, including this file, may be copied, modified,
// propagated, or distributed except as permitted in COPYRIGHT.txt.
// Licensed under the Apache License, Version 2.0.

using System.Collections.Generic;
using System.Diagnostics;

namespace Imazen.Profiling
{
    public class OpBenchmarkResults : IConcurrencyResults
    {
        public int ThrowawayThreads { get; set; }

        public int ParallelThreads { get; set; }


        public IEnumerable<ProfilingResultNode> ThrowawayRuns { get; set; }

        public IEnumerable<ProfilingResultNode> SequentialRuns { get; set; }

        /// <summary>
        ///     Includes houskeeping, setup, teardown, GC.Collect() and Thread.Sleep
        /// </summary>
        public long SequentialWallTicks { get; set; }

        public double SequentialWallMs => SequentialWallTicks * 1000 / (double)Stopwatch.Frequency;

        public double SequentialHouskeepingMs => SequentialWallMs - SequentialRuns.ExclusiveMs().Sum;

        public IEnumerable<ProfilingResultNode> ParallelRuns { get; set; }

        public long ParallelWallTicks { get; set; }

        public double ParallelWallMs => ParallelWallTicks * 1000 / (double)Stopwatch.Frequency;

        public long ParallelUniqueTicks { get; set; }

        public double ParallelUniqueMs => ParallelUniqueTicks * 1000 / (double)Stopwatch.Frequency;


        public double ParallelHouskeepingMs => ParallelWallMs - ParallelUniqueMs;


        /// <summary>
        ///     Number of virtual cores on the machine
        /// </summary>
        public int CoreCount { get; set; }


        public string SegmentName { get; set; }


        public long PrivateBytesBefore { get; set; }
        public long PrivateBytesWarm { get; set; }
        public long PrivateBytesAfter { get; set; }

        public long ManagedBytesBefore { get; set; }

        public long ManagedBytesWarm { get; set; }
        public long ManagedBytesAfter { get; set; }
    }
}