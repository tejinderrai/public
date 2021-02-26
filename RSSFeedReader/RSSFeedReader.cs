using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace MSWebDeveloperConsoleApp
{
    class RSSFeedReader
    {
        public static string MSDotNetBobURL = "https://devblogs.microsoft.com/dotnet/feed/";
        public async static Task<List<RSSFeedItem>> ReadArticlesWithWebClient(string url, string FeedType)
        {
            List<RSSFeedItem> results = new List<RSSFeedItem>();

            try
            {
                XDocument document;

                    using (HttpClient client = new HttpClient())
                    {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                        var streamAsync = await client.GetStreamAsync(url);

                        Stream result = streamAsync;

                        List<RSSFeedItem> templist = new List<RSSFeedItem>();
                        document = System.Xml.Linq.XDocument.Load(result);

                        results = (from descendant in document.Descendants("item")
                                   select new RSSFeedItem()
                                   {
                                       Description = descendant.Element("description").Value,
                                       Title = descendant.Element("title").Value,
                                       PublicationDate = descendant.Element("pubDate").Value,
                                       Link = descendant.Element("link").Value,
                                       CloudVendor = FeedType
                                   }).ToList();

                }
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
            }
            return results;
        }

        public async static Task<List<RSSFeedItem>> GetRSSFeedItems()
        {
            var results = await RSSFeedReader.ReadArticlesWithWebClient(MSDotNetBobURL, "DotNetBLog");

            return results;
        }
    }
}
