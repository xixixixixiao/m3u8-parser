﻿using M3U8.Parser.Adapters;
using M3U8.Parser.Core;
using M3U8.Parser.Utilities;
using System;
using System.Collections.Generic;
using System.IO;

namespace M3U8.Parser.AttributeReaders
{
    internal class MediaAttributeReader : AttributeReader
    {
        protected override bool CanRead(string key)
        {
            return string.Equals("#EXTINF", key);
        }

        protected override void Write(M3UFileInfo fileInfo, string value, LineReader reader)
        {
            if (fileInfo.MediaFiles == null)
                fileInfo.MediaFiles = new List<M3UMediaInfo>();
            var m3UmediaInfo = new M3UMediaInfo();
            var strArray     = value.Split(new char[1] {','}, StringSplitOptions.RemoveEmptyEntries);
            if (strArray.Length != 0)
            {
                m3UmediaInfo.Duration = To.Value<float>(strArray[0]);
                m3UmediaInfo.Title    = strArray.Length > 1 ? strArray[1].Trim() : string.Empty;
            }

            if (!reader.MoveNext())
                throw new InvalidDataException("Invalid M3U file. Missing a media URI.");

            var relativeUri = new Uri(reader.Current.Trim(), UriKind.RelativeOrAbsolute);
            if (!relativeUri.IsAbsoluteUri && !relativeUri.IsWellFormedOriginalString())
                throw new InvalidDataException("Invalid M3U file. Include a invalid media URI.",
                    new UriFormatException(reader.Current));

            if (!relativeUri.IsAbsoluteUri)
            {
                var baseUri = Configuration.Default.BaseUri;
                if (baseUri == null && reader.Adapter is NetworkAdapter adapter)
                    baseUri = new Uri(
                        adapter.Uri.GetComponents(UriComponents.SchemeAndServer | UriComponents.UserInfo,
                            UriFormat.SafeUnescaped), UriKind.Absolute);
                if (baseUri != null)
                    m3UmediaInfo.Uri = new Uri(baseUri, relativeUri);
            }

            if (m3UmediaInfo.Uri == null)
                m3UmediaInfo.Uri = relativeUri;
            fileInfo.MediaFiles.Add(m3UmediaInfo);
        }
    }
}