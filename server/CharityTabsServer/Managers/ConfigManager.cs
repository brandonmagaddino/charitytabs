using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace CharityTabsServer.Managers
{
    public class ConfigManager
    {
        private static bool isLoaded = false;
        private const String filename = @"AppConfig.xml";
        private static Dictionary<String, String> configurations;

        public static void load()
        {
            configurations = new Dictionary<string, string>();
            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlnodeList;
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnodeList = xmldoc.GetElementsByTagName("config");

            foreach (XmlNode xmlNode in xmlnodeList)
            {
                var id = xmlNode.Attributes?.GetNamedItem("id")?.Value;
                var value = xmlNode.Attributes?.GetNamedItem("value")?.Value;

                if (id != null && value != null)
                {   
                    configurations[id.Trim().ToLower()] = value;
                }
            }
            isLoaded = true;
        }

        public static String getString(string id, bool required = false)
        {
            if (isLoaded == false)
                load();

            if (id == null)
            {
                Console.WriteLine("[ConfigManager] Error looking for NULL key");

                if (required)
                    throw new Exception("Missing required configuration " + id);

                return null;
            }

            id = id.Trim().ToLower();

            if (!configurations.ContainsKey(id))
            {
                Console.WriteLine("[ConfigManager] Looking for unknown key: " + id);

                if (required)
                    throw new Exception("Missing required configuration " + id);

                return null;
            }

            return configurations[id];

        }

        public static double getDouble(string id, bool required = false)
        {
            double result = 0.00;

            var StrValue = getString(id, required);

            if (StrValue == null)
                return result;
            
            Double.TryParse(StrValue, out result);

            return result;
        }

        public static double getInt(string id, bool required = false)
        {
            int result = 0;

            var StrValue = getString(id, required);

            if (StrValue == null)
                return result;

            Int32.TryParse(StrValue, out result);

            return result;
        }

        public static bool getBool(string id, bool required = false)
        {
            bool result = false;

            var StrValue = getString(id, required);

            if (StrValue == null)
                return false;

            Boolean.TryParse(StrValue, out result);

            return result;
        }
    }
}
