using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmalgamaParser
{
    interface IParserSettings
    {
        string BaseUrl { get; set; }
        string Song { get; set; }
        string Artist { get; set; }
    }
}
