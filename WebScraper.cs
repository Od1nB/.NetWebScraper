using HtmlAgilityPack;

public static class WebScraper
{

    private static List<string> ParseAndReturnOfferings(string html)
    {
        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);
        var articlesList = new List<string>();
        var headlines = htmlDocument.DocumentNode.SelectNodes("//h1/span");
        foreach (var headline in headlines)
        {
            articlesList.Add(headline.InnerText);
        }
        return articlesList;
    }

    private static Task<string> GetHtml()
    {
        string websiteUrl = "https://www.kode24.no";
        HttpClient httpClient = new HttpClient();
        return httpClient.GetStringAsync(websiteUrl);
    }

static async Task Main(string[] args)
{
    Console.WriteLine("Getting html");
    var html = await GetHtml();
    Console.WriteLine("Parsing html");
    var data =  ParseAndReturnOfferings(html);
    Console.WriteLine("Found "+ data.Count + " Articles on kode24.no");
    Console.WriteLine("These are: \n");
    foreach (var art in data)
    {
        Console.WriteLine(art.TrimEnd().TrimStart()+ "\n");
    }
}

}

