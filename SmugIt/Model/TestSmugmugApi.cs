using Newtonsoft.Json;
using SmugMug.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmugIt.Model
{
    public class TestSmugmugApi
    {
        public void Test()
        {
            string apikey = SmugItConfigurationManager.Instance.Configuration.Credential.ApiKey;

            OAuthCredentials oAuthCredentials = new OAuthCredentials(apikey); // CONSUMER_KEY is the API Key received from SmugMug`
            SmugMugAPI api = new SmugMugAPI(LoginType.Anonymous, oAuthCredentials);
            //var test = api.GetUser("corleone00");
            //var album = api.GetAlbum("Etna2011").GetAwaiter().GetResult();

            //Get access to the user you want to enumerate albums for
            User user = api.GetUser("alberic").GetAwaiter().GetResult();
            Console.WriteLine(user.Name);

            var rootNode = api.GetRootNode(user).GetAwaiter().GetResult();// .GetFolder(user, "").GetAwaiter().GetResult();
            var nodes = api.GetChildNodes(rootNode).GetAwaiter().GetResult();
        }
    }
}
