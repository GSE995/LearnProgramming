using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace AmalgamaParser
{
    class AmalgamaParsers : IParser<List<string>[]>
    {
        public List<string>[] Parse(IHtmlDocument document)
        {
            var originSong = new List<string>();
            var translateSong = new List<string>();

            List<string>[] list = new List<string>[2];

            var items = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("original"));

            foreach (var item in items)
            {
                originSong.Add(item.TextContent);
            }

            var itemsT = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("translate"));

            foreach (var item in itemsT)
            {
                translateSong.Add(item.TextContent);
            }

            list[0] = originSong;
            list[1] = translateSong;

            return list.ToArray();
        }

    }
}
