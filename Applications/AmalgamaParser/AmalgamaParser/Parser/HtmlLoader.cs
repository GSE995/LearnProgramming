using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;


namespace AmalgamaParser
{
    class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;
        public HtmlLoader(IParserSettings setting)
        {
            client = new HttpClient();
            url = $"{setting.BaseUrl}/{setting.Artist}/{setting.Song}/";
        }

        public async Task<string> GetSource()
        {
            var currentUrl = url;
            var response = await client.GetAsync(currentUrl);
            string source = null;
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
