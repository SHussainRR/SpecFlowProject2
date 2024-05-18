using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SpecFlowProject2
{
    public  class ConfigImportor
    {
        public JObject details;
        public ConfigImportor() {
            string jsonString = File.ReadAllText("E:\\Working Repositories\\SQA\\SpecFlowProject2\\SpecFlowProject2\\data.json");
            details = JObject.Parse(jsonString);

        }
    }
}
