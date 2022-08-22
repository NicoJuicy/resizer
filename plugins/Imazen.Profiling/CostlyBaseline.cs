// Copyright (c) Imazen LLC.
// No part of this project, including this file, may be copied, modified,
// propagated, or distributed except as permitted in COPYRIGHT.txt.
// Licensed under the Apache License, Version 2.0.

using System;

namespace Imazen.Profiling
{
    public class CostlyBaseline
    {
        public void DoWork()
        {
            //Allocate 16MiB +4MiB of memory, fill 16MiB memory with a 32-byte pattern, then downscale
            var factor = 2;
            var sx = 4096;
            var sy = sx;
            var dx = sx / factor;
            var dy = dx;
            var fromBuffer = new byte[sx * sy];

            var toBuffer = new byte[dx * dy];

            var pattern = new byte[]
            {
                5, 23, 62, 88, 1, 201, 192, 36, 0, 0, 129, 177, 159, 245, 255, 108, 183, 93, 17, 16, 1, 201, 192, 36, 0,
                0, 129, 177, 245, 255, 108, 183
            };
            for (var i = 0; i < sx * sy; i += 32) Array.Copy(pattern, 0, fromBuffer, i, 32);

            for (var y = 0; y < dy; y++)
            for (var x = 0; x < dx; x++)
            {
                var destIx = dx * y + x;

                var total = 0;
                for (var yf = 0; yf < factor; yf++)
                for (var xf = 0; xf < factor; xf++)
                    total += fromBuffer[sx * (dy + yf) * factor + (x + xf) * factor];

                toBuffer[destIx] = (byte)(total / (factor * factor));
            }
        }
    }
}