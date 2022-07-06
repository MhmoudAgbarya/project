using System.Text.RegularExpressions;
using System.IO;
using System.Web;
internal class Program
{
    private static async Task Main(string[] args)
    {
        using var client = new HttpClient();

        client.DefaultRequestHeaders.Add("User-Agent", "C# console program");

        var url = System.Uri.UriSchemeHttps;
        //  HttpContext.Current.Request.Url.AbsoluteUri;

        var content = await client.GetStringAsync("https://www.espn.com/");


       
       var str = Regex.Replace(content, @"<script[^>]*>[\s\S]*?</script>", " ");
       str = Regex.Replace(str, @"<style[^>]*>[\s\S]*?</style>", " ");
       str = Regex.Replace(content, "<.*?>", " ");
       str = Regex.Replace(str, @"\s+", "newWord");
       var strArr = str.Split("newWord");

       //لازم اعمل for داخلية
       //ا بتفحص اذا موجودة الكلمة، بتمرق على كل النص عشان اعرف كم مرة تكررت

        //    bool x = false;
       if (File.Exists("bad words.txt.txt"))
        {
            int badWordsCounter = 0;
            //webSiteCounter = 0;
            StreamReader badwords = new StreamReader("bad words.txt.txt");
            var badWordArray = badwords.ReadLine()?.Split("/");
            if (badWordArray != null)
            {
                for(int i=0; i< strArr.Length; i++)
                {
                    var temp = strArr[i];
                    var doesInclude = Array.Find(badWordArray,element=>element == strArr[i]);
                    if(doesInclude != null)
                    {
                        badWordsCounter++;
                        doesInclude = null;
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