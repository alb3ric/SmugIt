using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmugIt.Model.Domain
{


    public class SmugItSettings
    {
        public class SmugItSettingsCredential
        {
            public string ApiKey { get; set; }
        }
        
        public static SmugItSettings LoadFromFile(string filename)
            => JsonConvert.DeserializeObject(File.ReadAllText(filename), typeof(SmugItSettings)) as SmugItSettings;

        public SmugItSettingsCredential Credential { get; set; }
    }
}
