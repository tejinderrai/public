using System;
using System.Threading.Tasks;

namespace MSWebDeveloperConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Reading RSS Feed...");

            var results = await RSSFeedReader.GetRSSFeedItems();


            foreach (RSSFeedItem item in results)
            {
                DateTime dt = DateTime.Parse(item.PublicationDate);
                string newDate = dt.ToString();
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine(item.Link.ToString());
                Console.WriteLine(DateTime.Parse(item.PublicationDate));
                Console.WriteLine(item.Description.ToString());

                Console.WriteLine("----------------------------------------------");
                Console.ReadKey();
            }

            Console.WriteLine("Press key to exit");
            Console.ReadKey();
        }
    }
}
