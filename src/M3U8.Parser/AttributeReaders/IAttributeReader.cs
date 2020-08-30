using M3U8.Parser.Core;

namespace M3U8.Parser.AttributeReaders
{
    internal interface IAttributeReader
    {
        bool Read(LineReader reader, M3UFileInfo fileInfo);
    }
}