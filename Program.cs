using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
internal class Program
{
    private static async Task Main(string[] args)
    {
        using var client = new HttpClient();

        client.DefaultRequestHeaders.Add("User-Agent", "C# console program");

        // var content = await client.GetStringAsync("http://webcode.me");
        var content = await client.GetStringAsync("https://www.espn.com/");
    //     var str = Regex.Replace(content, "(<style.+?</style>)|(<script.+?</script>)", " ", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    //     str = Regex.Replace(str, "(<img.+?>)", " ", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    //     str = Regex.Replace(str, "(<o:.+?</o:.+?>)", " ", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    //     str = Regex.Replace(str, "<!--.+?-->", " ", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    //     str = Regex.Replace(str, "class=.+?>", ">", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    //     str = Regex.Replace(str, "class=.+?\\s", " ", RegexOptions.IgnoreCase | RegexOptions.Singleline);


       
       var str = Regex.Replace(content, @"<script[^>]*>[\s\S]*?</script>", " ");
       str = Regex.Replace(str, @"<style[^>]*>[\s\S]*?</style>", " ");
       str = Regex.Replace(content, "<.*?>", " ");
       str = Regex.Replace(str, @"\s+", " ");

    

       var doesInclude = str.Contains("img");

        Console.WriteLine(str);
        Console.WriteLine(doesInclude);

    }
}