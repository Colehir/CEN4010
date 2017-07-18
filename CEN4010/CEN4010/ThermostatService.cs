using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CEN4010
{
    public interface IRestService
    {
        Task<ThermostatItem> GetThermostat(int systemNumber);

        Task UpdateThermostat(ThermostatItem item, bool isNewItem);
    }

    class ThermostatService : IRestService
    {
        HttpClient client = new HttpClient();

        public ThermostatService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<ThermostatItem> GetThermostat(int systemNumber)
        {
            var Items = new ThermostatItem();
            var RestUrl = "http://www.colehirapara.com/api/thermostat/" + systemNumber.ToString();
            var uri = new Uri(string.Format(RestUrl, string.Empty));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<ThermostatItem>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Error: {0}", ex.Message);
            }

            return Items;
        }

        public async Task UpdateThermostat(ThermostatItem item, bool isNewItem = false)
        {
            var RestUrl = "http://www.colehirapara.com/api/thermostat";
            var uri = new Uri(RestUrl+"/"+item.Id.ToString());

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"TodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }
    }
    public class ThermostatManager
    {
        IRestService restService;

        public ThermostatManager(IRestService service)
        {
            restService = service;
        }

        public async Task<ThermostatItem> GetThermostat(int systemNumber)
        {
            ThermostatItem temp = await restService.GetThermostat(systemNumber);
            return temp;
        }

        public Task UpdateThermostat(ThermostatItem item, bool isNewItem = false)
        {
            return restService.UpdateThermostat(item, isNewItem);
        }

    }
}
