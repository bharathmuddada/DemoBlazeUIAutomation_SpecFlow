using Newtonsoft.Json.Linq;

namespace DemoBlazeCoreFW_SpecFlow
{
    public  class ConfigReaderHelpers
    {

        public static string GetconfigDetails(string keyname)
        {
            string configValue=null;
            JObject jsonobjectdata;
            try
            { 
                string filepath = Directory.GetCurrentDirectory() + "/TestSettings.json";
                jsonobjectdata = JObject.Parse(File.ReadAllText(filepath));
                configValue = jsonobjectdata[keyname].ToString();
           

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }
            return configValue;
        }
    }
}