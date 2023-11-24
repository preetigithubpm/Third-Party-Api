using Newtonsoft.Json;
using Twilio.Rest.Api.V2010.Account.Usage.Record;

namespace task29August.NewFolder.RequestDto
{
    public static class WorkingWithSessions
    {
        public static void SetObjectasJson(ISession session,string key,object value)
        {
            session.SetString(key,JsonConvert.SerializeObject(value));
        }
        public static T? GetObjectFromJson<T>(ISession session,string key)
        {
            var value=session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
