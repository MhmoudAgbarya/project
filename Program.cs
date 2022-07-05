using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
internal class Program
{
    private static async Task Main(string[] args)
    {
        using var client = new HttpClient();

        client.DefaultRequestHeaders.Add("User-Agent", "C# console program");

        var content = await client.GetStringAsync("https://www.espn.com/");


       
       var str = Regex.Replace(content, @"<script[^>]*>[\s\S]*?</script>", " ");
       str = Regex.Replace(str, @"<style[^>]*>[\s\S]*?</style>", " ");
       str = Regex.Replace(content, "<.*?>", " ");
       str = Regex.Replace(str, @"\s+", " ");

    

       var doesInclude = str.Contains("img");

        Console.WriteLine(str);
        Console.WriteLine(doesInclude);

    }
}