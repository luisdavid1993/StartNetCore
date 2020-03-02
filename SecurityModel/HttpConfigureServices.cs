using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityModel
{
   public class HttpConfigureServices
    {
        public string endpointUrl { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public TimeSpan? closeTimeout { get; set; }
        public int? maxBufferSize { get; set; }
        public long? maxReceivedMessageSize { get; set; }
        public TimeSpan? openTimeout { get; set; }
    }
}
