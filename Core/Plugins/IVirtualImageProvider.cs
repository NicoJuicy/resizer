// Copyright (c) Imazen LLC.
// No part of this project, including this file, may be copied, modified,
// propagated, or distributed except as permitted in COPYRIGHT.txt.
// Licensed under the Apache License, Version 2.0.

using System.Collections.Specialized;

namespace ImageResizer.Plugins
{
    /// <summary>
    ///     Implement this to allow your class (or VirtualPathProvider subclass) to be used without registering it with the
    ///     whole ASP.NET system.
    /// </summary>
    public interface IVirtualImageProvider
    {
        /// <summary>
        ///     Returns true if the specified request should be handled by this virtual image provider
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        bool FileExists(string virtualPath, NameValueCollection queryString);

        /// <summary>
        ///     Returns a virtual file instance for the specified path and querystring.
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        IVirtualFile GetFile(string virtualPath, NameValueCollection queryString);
    }
}