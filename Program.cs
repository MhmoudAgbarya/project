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

        var content = await client.GetStringAsync("https://www.javatpoint.com/c-sharp-multidimensional-array");


       
       var str = Regex.Replace(content, @"<script[^>]*>[\s\S]*?</script>", " ");
       str = Regex.Replace(str, @"<style[^>]*>[\s\S]*?</style>", " ");
       str = Regex.Replace(content, "<.*?>", " ");
       str = Regex.Replace(str, @"\s+", "newWord");
       var strArr = str.Split("newWord");


       if (File.Exists("bad words.txt.txt"))
        {
            int badWordsCounter = 0;
            StreamReader badwords = new StreamReader("bad words.txt.txt");
            var badWordArray = badwords.ReadLine()?.Split("/");
            
            string [,] badwordsmatrix=new string [badWordArray.Length,2];

            if (badWordArray != null)
            {
                for(int k=0; k<badWordArray.Length; k++)
                {
                    badwordsmatrix[k,0]=badWordArray[k];
                    badwordsmatrix[k,1]="0";
                }
                for(int i=0; i< strArr.Length; i++)
                {
                    var temp = strArr[i];
                    var doesInclude = Array.Find(badWordArray,element=>element == strArr[i]);
                    if(doesInclude != null)
                    {
                        for(int g=0; g<badWordArray.Length;g++)
                        {
                            if(badwordsmatrix[g,0]== badWordArray[g])
                            {
                                Int32.TryParse(badwordsmatrix[g,1], out int j);
                                j++;
                                badwordsmatrix[g,1]=j.ToString();
                            }
                        }
                        badWordsCounter++;
                        doesInclude = null;
                    }
                    
                }
                for(int m=0; m<badWordArray.Length;m++)
                {
                    Console.Write(badwordsmatrix[m,0]);
                    Console.WriteLine(badwordsmatrix[m,1]);
                    
                }
            }
            badwords.Close();
        }
    

    }
}