using M3U8.Parser.Core;
using M3U8.Parser.Utilities;

namespace M3U8.Parser.AttributeReaders
{
    internal class SequenceAttributeReader : AttributeReader
    {
        protected override bool CanRead(string key)
        {
            return string.Equals("#EXT-X-MEDIA-SEQUENCE", key);
        }

        protected override void Write(M3UFileInfo fileInfo, string value, LineReader reader)
        {
            fileInfo.MediaSequence = To.Value<int>(value);
        }
    }
}