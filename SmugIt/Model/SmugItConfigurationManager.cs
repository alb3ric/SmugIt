using Newtonsoft.Json;
using SmugIt.Model.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmugIt.Model
{
    public sealed class SmugItConfigurationManager
    {
        private static volatile SmugItConfigurationManager instance;
        private static object syncRoot = new Object();

        private SmugItConfigurationManager() { }

        public static SmugItConfigurationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new SmugItConfigurationManager();
                            instance.LoadConfigurationFromFile();
                        }
                    }
                }

                return instance;
            }
        }

        public SmugItSettings Configuration { get; set; }

        public void LoadConfigurationFromFile()
        {
            Configuration = SmugItSettings.LoadFromFile(SmugItConstants.ConfigFileName);
        }
        
    }
}
