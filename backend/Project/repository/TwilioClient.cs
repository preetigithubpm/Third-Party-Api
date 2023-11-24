using Twilio.Clients;
using Twilio.Http;

namespace task29August.repository
{
    public class TwilioClient : ITwilioRestClient
    {
        private readonly ITwilioRestClient _innerclient;

        public TwilioClient(IConfiguration config, System.Net.Http.HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add("X-Custom-Header", "CustomTwilioRestClient-Demo");
            _innerclient = new TwilioRestClient(
                config["Twilio:AccountSID"],
                config["Twilio:AuthToken"],
                httpClient: new SystemNetHttpClient(httpClient)
                );
        }
        public Response Request(Request request) => _innerclient.Request(request);
        public Task<Response> RequestAsync(Request request) => _innerclient.RequestAsync(request);

        internal static void Init(string accountSid, string authToken)
        {
            throw new NotImplementedException();
        }

        public string AccountSid => _innerclient.AccountSid;

        public string Region => _innerclient.Region;

        public global::Twilio.Http.HttpClient HttpClient =>_innerclient.HttpClient;

      
    }
}
