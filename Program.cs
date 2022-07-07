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

        var content = await client.GetStringAsync("https://www.javatpoint.com/");//تخزين محتويات الموقع
        
        // Console.WriteLine("enter the web: ");// ادخال الموقع
        // var web = Console.ReadLine();
        // var content = await client.GetStringAsync(web);//تخزين محتويات الموقع
       
       var str = Regex.Replace(content, @"<script[^>]*>[\s\S]*?</script>", " ");
       str = Regex.Replace(str, @"<style[^>]*>[\s\S]*?</style>", " ");
       str = Regex.Replace(content, "<.*?>", " ");
       str = Regex.Replace(str, @"\s+", "newWord");
       var strArr = str.Split("newWord");


       if (File.Exists("bad words.txt.txt"))//فحص اذا كان الملف موجود أم لا؟
        {
            int badWordsCounter = 0;//عداد كم مرة تكررت الكلمة
            StreamReader badwords = new StreamReader("bad words.txt.txt");//قراءة الكلمات من الملف
            var badWordArray = badwords.ReadLine()?.Split("/");//تخزين الكلمات بعد القراءة

            string [,] badwordsmatrix=new string [badWordArray.Length,2];//بناء مصفوفة ثنائية الابعاد لحفظ الكلمات وكم مرة تكررت

            if (badWordArray != null)//فحص اذا كان كلمات؟
            {
                for(int k=0; k<badWordArray.Length; k++)//تخزين الكلمات في المصفوفة ثنائية الابعاد
                {
                    badwordsmatrix[k,0]=badWordArray[k];
                    badwordsmatrix[k,1]="0";
                }
                for(int i=0; i< strArr.Length; i++)//
                {
                    var temp = strArr[i];
                    var doesInclude = Array.Find(badWordArray,element=>element == strArr[i]);
                    if(doesInclude != null)// عداد كم مرة تكررت كل كلمة
                    {
                        for(int g=0; g<badWordArray.Length;g++)//؟
                        {
                            if(badwordsmatrix[g,0]== doesInclude)
                            {
                                Int32.TryParse(badwordsmatrix[g,1], out int j);
                                j++;
                                badwordsmatrix[g,1]=j.ToString();
                            }
                        }
                        badWordsCounter++;
                        doesInclude = null;
                    }// تخزين العداد لكل كلمة بالمصفوفة ثنائية الابعاد
                    
                }
                for(int m=0; m<badWordArray.Length;m++)// طباعة الكلمات وكم مرة تكررت
                {
                    Console.Write(" {0} : ",badwordsmatrix[m,0]);
                    Console.WriteLine(badwordsmatrix[m,1]);
                }
            }
            badwords.Close();// اغلاق ملف الكلمات
        }
    

    }
}