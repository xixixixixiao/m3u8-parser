using M3U8.Parser.Core;

namespace M3U8.Parser.AttributeReaders
{
    internal class EndListAttributeReader : AttributeReader
    {
        protected override bool CanRead(string key)
        {
            return string.Equals("#EXT-X-ENDLIST", key);
        }

        protected override bool ShouldTerminate()
        {
            return true;
        }

        protected override void Write(M3UFileInfo fileInfo, string value, LineReader reader)
        {
        }
    }
}