using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
internal class Program
{
    private static async Task Main(string[] args)
    {
        // Console.WriteLine("Hello, World!");
        using var client = new HttpClient();

        client.DefaultRequestHeaders.Add("User-Agent", "C# console program");

        var content = await client.GetStringAsync("http://webcode.me");

       var str = Regex.Replace(content, "<.*?>", "!").Split("!");

        // Console.WriteLine(str);
        // var str = content.Replace(@"<[^>]*>", "");
        for(int c = 0; c < str.Length; c++){

        Console.WriteLine(str[c]);
        Console.WriteLine("xxxxxxxxxxxxxx");
        }
    }
}