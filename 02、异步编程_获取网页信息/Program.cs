namespace _02_异步编程_获取网页信息
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await DownLoadHtmlAsync("http://www.baidu.com", "D:\\学习\\计算机\\.NET6杨中科\\DoNET6杨中科\\02、异步编程_获取网页信息\\baidu.txt");
        }
        static async Task DownLoadHtmlAsync(string Url, string FileName)
        {
            using (HttpClient hc = new HttpClient())
            { 
                string html = await hc.GetStringAsync(Url);
                await File.WriteAllTextAsync(FileName, html);

            }
        }
    }
}
