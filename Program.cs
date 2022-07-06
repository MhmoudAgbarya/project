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

       //لازم اعمل for داخلية
       //ا بتفحص اذا موجودة الكلمة، بتمرق على كل النص عشان اعرف كم مرة تكررت

        //    bool x = false;
       if (File.Exists("bad words.txt"))
        {
            int badWordsCounter = 0;
            //webSiteCounter = 0;
            StreamReader badwords = new StreamReader("bad words.txt");
            var badWordArray = badwords.ReadLine();
            if (badWordArray != null)
            {
                for(int i=0; i< str.Length; i++)
                {
                    doesInclude = badWordArray.Contains(str[i]);
                    if(doesInclude == true)
                    {
                        badWordsCounter++;
                        doesInclude = false;
                    }
                    Console.WriteLine(badWordsCounter);
                }

            }
            badwords.Close();
            // if (x == false)// الكلمة مش موجودة
            // {
            //     Console.WriteLine("the word is not found!!!");
            //     Console.ReadKey();
            // }
        }
    

    }
}