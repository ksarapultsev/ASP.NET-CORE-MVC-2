using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("http://mail.ru");
            return httpMessage.Content.Headers.ContentLength;

            //HttpClient client = new HttpClient();
            //var httpTask = client.GetAsync("http://mail.ru");
            //return httpTask.ContinueWith(
            //    (Task<HttpResponseMessage> antecedent) => 
            //    { return antecedent.Result.Content.Headers.ContentLength; });
        }
    }
}
