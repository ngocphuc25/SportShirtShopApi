using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class IgnoreIdConverter : JsonConverter
{
    public override bool CanConvert(Type objectType) => true;

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var jObject = JObject.FromObject(value);
        // Remove any property that starts with '$'
        foreach (var property in jObject.Properties().Where(p => p.Name.StartsWith("$")).ToList())
        {
            property.Remove();
        }
        jObject.WriteTo(writer);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        // Handle deserialization if needed
        return serializer.Deserialize(reader, objectType);
    }
}