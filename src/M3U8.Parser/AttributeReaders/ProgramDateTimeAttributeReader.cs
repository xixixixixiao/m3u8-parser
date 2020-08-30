using System;
using M3U8.Parser.Core;
using M3U8.Parser.Utilities;

namespace M3U8.Parser.AttributeReaders
{
    internal class ProgramDateTimeAttributeReader : AttributeReader
    {
        protected override bool CanRead(string key)
        {
            return string.Equals("#EXT-X-PROGRAM-DATE-TIME", key);
        }

        protected override void Write(M3UFileInfo fileInfo, string value, LineReader reader)
        {
            fileInfo.ProgramDateTime = To.Value<DateTime>(value);
        }
    }
}