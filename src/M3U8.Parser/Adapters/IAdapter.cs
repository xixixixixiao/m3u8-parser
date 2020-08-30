using System;
using System.IO;

namespace M3U8.Parser.Adapters
{
    internal interface IAdapter : IDisposable
    {
        bool IsConnected { get; }

        Stream Connect();
    }
}