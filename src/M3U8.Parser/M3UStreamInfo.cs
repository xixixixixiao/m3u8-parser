using System;

namespace M3U8.Parser
{
    public class M3UStreamInfo
    {
        public int? ProgramId { get; set; }

        public int? Bandwidth { get; set; }

        public string Codecs { get; set; }

        public string Resolution { get; set; }

        public Uri Uri { get; set; }
    }
}