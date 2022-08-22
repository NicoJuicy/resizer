// Copyright (c) Imazen LLC.
// No part of this project, including this file, may be copied, modified,
// propagated, or distributed except as permitted in COPYRIGHT.txt.
// Licensed under the Apache License, Version 2.0.

using System.Threading.Tasks;
using System.Web;
using ImageResizer.Util;

namespace ImageResizer.Plugins.Basic
{
    /// <summary>
    ///     Implements IHttpHandler, serves content for the NoCache plugin
    /// </summary>
    public class NoCacheAsyncHandler : AsyncUtils.AsyncHttpHandlerBase
    {
        private IAsyncResponsePlan e;

        public NoCacheAsyncHandler(IAsyncResponsePlan e)
        {
            this.e = e;
        }

        public override Task ProcessRequestAsync(HttpContext context)
        {
            context.Response.StatusCode = 200;
            context.Response.BufferOutput = true; //Same as .Buffer. Allows bitmaps to be disposed quicker.
            context.Response.ContentType = e.EstimatedContentType;
            return e.CreateAndWriteResultAsync(context.Response.OutputStream, e);
        }
    }
}