using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Site.Shared;

public class StringToNumericConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(int) || objectType == typeof(long) || objectType == typeof(double) || objectType == typeof(decimal) || objectType == typeof(float) || objectType == typeof(short);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JToken token = JToken.Load(reader);
        if (token.Type == JTokenType.String)
        {
            if (objectType == typeof(int))
                return int.Parse(token.ToString());

            if (objectType == typeof(long))
                return long.Parse(token.ToString());

            if (objectType == typeof(double))
                return double.Parse(token.ToString());

            if (objectType == typeof(decimal))
                return decimal.Parse(token.ToString());

            if (objectType == typeof(float))
                return float.Parse(token.ToString());

            if (objectType == typeof(short))
                return short.Parse(token.ToString());
        }
        return token.ToObject(objectType);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
