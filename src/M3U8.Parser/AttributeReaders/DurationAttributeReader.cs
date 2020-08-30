using M3U8.Parser.Core;
using M3U8.Parser.Utilities;

namespace M3U8.Parser.AttributeReaders
{
    internal class DurationAttributeReader : AttributeReader
    {
        protected override bool CanRead(string key)
        {
            return string.Equals("#EXT-X-TARGETDURATION", key);
        }

        protected override void Write(M3UFileInfo fileInfo, string value, LineReader reader)
        {
            fileInfo.TargetDuration = To.Value<int>(value);
        }
    }
}