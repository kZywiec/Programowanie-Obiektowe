
// Tested on .NET 5

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Text;
using Newtonsoft.Json; // <---- install it with NuGet (https://www.nuget.org/packages/Newtonsoft.Json/)

public class SnippetsUtils
{

    /*
    public static void Main()
    {
        int pageNumber = 1;
        int pageSize = 5;
        string snippetsType = "cs"; // C#

        PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);

        Console.WriteLine($"PageNumber: {reponse.PageNumber}");
        Console.WriteLine($"PagesCount: {reponse.PagesCount}");
        Console.WriteLine($"PageSize:   {reponse.PageSize}  ");
        Console.WriteLine($"TotalCount: {reponse.TotalCount}");

        Console.WriteLine();
        Console.WriteLine("Snippets:");

        foreach (SnippetReponse snippet in reponse.Batches)
            Console.WriteLine("    (" + snippet.Size + ")    " + snippet.Name + "    [" + snippet.Type + "]    " + snippet.CreationTime + "    " + snippet.UpdateTime);

        // Example ouput:
        //
        //     PageNumber: 1
        //     PagesCount: 12
        //     PageSize:   5
        //     TotalCount: 60
        //     
        //     Snippets:
        //         (1)    C# - fetch current Dirask snippets and display in console    [cs]    2022-05-27 03:23:49    2022-05-27 04:42:43
        //         (2)    C# - request web URL and get response content                [cs]    2022-05-27 02:05:36
        //         (1)    C# - async/await methods with synchronization                [cs]    2022-05-20 11:25:59    2022-05-20 21:16:17
        //         (2)    C# - lock statement usage example                            [cs]    2022-05-20 09:46:34    2022-05-22 01:37:16
        //         (2)    console.log() in C#                                          [cs]    2022-05-18 17:05:41    2022-05-22 19:09:07
    }
    */
    public static string FetchData(string url)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            ContentType type = new ContentType(response.ContentType ?? "text/plain;charset=" + Encoding.UTF8.WebName);
            Encoding encoding = Encoding.GetEncoding(type.CharSet ?? Encoding.UTF8.WebName);

            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream, encoding))
            {
                return reader.ReadToEnd();
            }
        }
    }

    public static PageReposne FetchSnippets(int pageNumber, int pageSize, string snippetsType)
    {
        string url = $"https://dirask.com/api/snippets?pageNumber={pageNumber}&pageSize={pageSize}&dataOrder=newest&dataGroup=batches&snippetsType={Uri.EscapeUriString(snippetsType)}";
        string data = FetchData(url);

        return DeserializeJson<PageReposne>(data);
    }

    public static T DeserializeJson<T>(string json)
    {
        JsonSerializer serializer = new JsonSerializer();

        using (StringReader stringReader = new StringReader(json))
        using (JsonReader jsonReader = new JsonTextReader(stringReader))
        {
            return serializer.Deserialize<T>(jsonReader);
        }
    }
}

public class PageReposne
{
    [JsonProperty("pageNumber")]
    public int PageNumber { get; set; }

    [JsonProperty("pagesCount")]
    public int PagesCount { get; set; }

    [JsonProperty("pageSize")]
    public int PageSize { get; set; }

    [JsonProperty("totalCount")]
    public int TotalCount { get; set; }

    [JsonProperty("batches")]
    public List<SnippetReponse> Batches { get; set; }
}

public class SnippetReponse
{
    [JsonProperty("size")]
    public int Size { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonProperty("updateTime")]
    public DateTime? UpdateTime { get; set; }
}
