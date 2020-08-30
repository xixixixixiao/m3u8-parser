using M3U8.Parser.Core;
using M3U8.Parser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M3U8.Parser.AttributeReaders
{
    internal class KeyAttributeReader : AttributeReader
    {
        protected override bool CanRead(string key)
        {
            return string.Equals("#EXT-X-KEY", key);
        }

        protected override void Write(M3UFileInfo fileInfo, string value, LineReader reader)
        {
            var source =
                value.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                     .Select(e => KV.Parse(e, '=').Value);
            if (fileInfo.Key == null && source.Any())
                fileInfo.Key = new M3UKeyInfo();
            foreach (var keyValuePair in source)
            {
                var key = keyValuePair.Key;
                if (key != "URI")
                {
                    if (key != "IV")
                    {
                        if (key == "METHOD")
                            fileInfo.Key.Method = keyValuePair.Value;
                    }
                    else
                        fileInfo.Key.IV = keyValuePair.Value;
                }
                else
                {
                    fileInfo.Key.Uri = Uri.TryCreate(keyValuePair.Value, UriKind.Absolute, out var result)
                        ? result
                        : null;
                }
            }
        }
    }
}