using M3U8.Parser.Core;
using M3U8.Parser.Utilities;
using System.Collections.Generic;

namespace M3U8.Parser.AttributeReaders
{
    internal abstract class AttributeReader : IAttributeReader
    {
        protected abstract bool CanRead(string key);

        protected virtual bool ShouldTerminate()
        {
            return false;
        }

        protected abstract void Write(M3UFileInfo fileInfo, string value, LineReader reader);

        public bool Read(LineReader reader, M3UFileInfo fileInfo)
        {
            var text = reader.Current?.Trim();
            if (string.IsNullOrEmpty(text) || '#' != text[0])
                return false;

            var keyValuePair = KV.Parse(text, ':').Value;
            if (!CanRead(keyValuePair.Key))
                return false;
            if (ShouldTerminate())
                return true;

            Write(fileInfo, keyValuePair.Value, reader);
            return false;
        }
    }
}