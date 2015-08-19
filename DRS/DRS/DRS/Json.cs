using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace DRS
{
    class Json
    {


    }
    public class DataParser
    {
        [JsonProperty(PropertyName = "Username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public string createdAt { get; set; }
        [JsonProperty(PropertyName = "objectId", NullValueHandling = NullValueHandling.Ignore)]
        public string objectId { get; set; }
        [JsonProperty(PropertyName = "updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public string updatedAt { get; set; }

        [JsonProperty(PropertyName = "Password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "PhoneNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "Email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        public override string ToString()
        {
            return Username;
        }

    }

    ////////////////////////////////////////////////////////////////// seprate 



    public class DataToList
    {
        [JsonProperty(PropertyName = "results")]
        public List<DataParser> results { get; set; }



        public List<string> GetStringList()
        {
            List<string> resultList = new List<string>();
        
            foreach (var item in results)
            {
                resultList.Add(item.Email);
                resultList.Add(item.Username);
            }
            return resultList;
        }

    }
    
}
