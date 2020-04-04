using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Dominio.Service
{
    public class HttpService
    {
        public static async Task<string> HttpRequestAsync(string url)
        {
            string html = string.Empty;


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            return html;
        }
    }
}
