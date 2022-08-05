// Copyright (c) Imazen LLC.
// No part of this project, including this file, may be copied, modified,
// propagated, or distributed except as permitted in COPYRIGHT.txt.
// Licensed under the Apache License, Version 2.0.

namespace ImageResizer.Configuration.Logging
{
    public interface ILoggerProvider
    {
        ILogger Logger { get; }
    }
}