using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharpStudy.CSharp5_0
{
    public class AsynchronousMembersTest
    {
        public async Task<Repository> GetRepositoryDetails()
        {
            HttpClient client = new HttpClient();
            Uri address = new Uri("https://api.github.com/repos/fabioono25/");
            client.BaseAddress = address;

            HttpResponseMessage response = await client.GetAsync("csharpstudy");

            if (response.IsSuccessStatusCode)
            {
                //var list = await response.Content.ReadAsAsync<IEnumerable<Product>>();
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Repository>(result);
            }
            else
            {
                return null;
            }
        }

        // asynchronous methods now defined as async keyword
        private static async void CallingVoidAsyncMethod()
        {
            //the presence of await keyword ensures that this method will be executed in asynchronous mode
            await DBProcess();
        }

        private static Task DBProcess()
        {
            return Task.Run(() =>
            {
                //execute some process
                System.Threading.Thread.Sleep(10000);
            });
        }
    }

    public class Repository
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}