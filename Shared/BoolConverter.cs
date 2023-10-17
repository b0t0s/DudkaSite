using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Site.Shared;

public class BoolConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(bool);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JToken token = JToken.Load(reader);
        if (token.Type == JTokenType.String)
        {
            return token.ToString() == "1";
        }
        return token.ToObject<bool>();
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
