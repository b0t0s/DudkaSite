﻿using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Globalization;

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
            string tokenValue = token.ToString();

            if (objectType == typeof(int))
                return (int)double.Parse(tokenValue, CultureInfo.InvariantCulture);

            if (objectType == typeof(long))
                return (long)double.Parse(tokenValue, CultureInfo.InvariantCulture);

            if (objectType == typeof(double))
                return double.Parse(tokenValue, CultureInfo.InvariantCulture);

            if (objectType == typeof(decimal))
                return decimal.Parse(tokenValue, CultureInfo.InvariantCulture);

            if (objectType == typeof(float))
                return float.Parse(tokenValue, CultureInfo.InvariantCulture);

            if (objectType == typeof(short))
                return (short)double.Parse(tokenValue, CultureInfo.InvariantCulture);
        }
        return token.ToObject(objectType);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
