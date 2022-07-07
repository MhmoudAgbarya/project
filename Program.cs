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
       str = Regex.Replace(str, @"\s+", " ");

    

       var doesInclude = str.Contains("img");
       Console.WriteLine(str);
       Console.WriteLine(doesInclude);

       //لازم اعمل for داخلية
       // بتفحص اذا موجودة الكلمة، بتمرق على كل النص عشان اعرف كم مرة تكررت
       

       
       bool x = false;
       if (File.Exists("badwords.txt"))
        {
            int badWordsCounter = 0;
            //webSiteCounter = 0;
            StreamReader badwords = new StreamReader("badwords.txt");
            var badWordArray = badwords.ReadLine();


            string [,] strwordsarray=new string [,]
            {

            };


            if (badWordArray != null)
            {
                for(int k=0; k< badWordArray.Length; k++)
                {
                    doesInclude = badWordArray.Contains(str[k]);
                    for(int i=0; i< str.Length; i++)
                    {
                    if(doesInclude == true)
                    {
                        badWordsCounter++;
                        doesInclude = false;
                        x = true;
                    }
                    }
                    Console.WriteLine(badWordsCounter);
                }

            }
            badwords.Close();

            if (x == false)// لا يوجد كلمات سيئة
            {
                Console.WriteLine("No bad words");
                Console.ReadKey();
            }
        }
    

    }
}