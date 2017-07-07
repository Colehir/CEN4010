using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CEN4010
{
    class ThermostatConnection
    {
        HttpClient client = new HttpClient();

        public ThermostatConnection()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }
    }
}
