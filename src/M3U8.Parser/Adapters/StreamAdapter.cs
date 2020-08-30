using System;
using System.IO;

namespace M3U8.Parser.Adapters
{
    internal class StreamAdapter : Adapter
    {
        public new Stream Stream => base.Stream;

        public StreamAdapter(Stream stream)
        {
            base.Stream = (stream ?? throw new ArgumentNullException("stream"));
        }

        protected override Stream CreateStream()
        {
            return Stream;
        }
	}
}