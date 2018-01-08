using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeRestService
{
    class Program
    {
        static void Main(string[] args)
        {
            async Task<IList<Catch>> GetCatchAsync()
            {
                using (HttpClient client = new HttpClient())
                {
                    string content = await client.GetStringAsync("http://localhost:59356/RestServiceImpl.svc/catch");
                    IList<Catch> cList = JsonConvert.DeserializeObject<IList<Catch>>(content);
                    return cList;
                }
            }
            var alist = GetCatchAsync().Result;
            foreach (var a in alist)
            {
                Console.WriteLine(a.navn);
            }
            Console.ReadLine();
        }
    }
}


