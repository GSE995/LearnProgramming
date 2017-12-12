using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core.TProger
{
    class TProgerSettings : IParserSettings
    {
        public TProgerSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }

        public TProgerSettings(int start, int end, string prefix) : this(start, end)
        {
            Prefix = prefix;
        }

        public string BaseUrl { get; set; } = "https://tproger.ru/tag";
        public string Section { get; set; } = "page/{CurrentId}";
        public string Prefix { get; set; } = "c-sharp";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
