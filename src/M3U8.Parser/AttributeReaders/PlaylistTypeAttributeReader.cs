using M3U8.Parser.Core;

namespace M3U8.Parser.AttributeReaders
{
    internal class PlaylistTypeAttributeReader : AttributeReader
    {
        protected override bool CanRead(string key)
        {
            return string.Equals("#EXT-X-PLAYLIST-TYPE", key);
        }

        protected override void Write(M3UFileInfo fileInfo, string value, LineReader reader)
        {
            fileInfo.PlaylistType = value;
        }
    }
}