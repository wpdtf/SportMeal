using System.Text.Json.Serialization;
using System.Text.Json;

namespace SportMeal.Domain.Converter;

public class JsonNumberEnumConverter<TEnum> : JsonConverter<TEnum> where TEnum : Enum
{
    public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt32(out int value))
        {
            return (TEnum)Enum.ToObject(typeToConvert, value);
        }

        throw new JsonException("Ошибка определения значения.");
    }

    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(Convert.ToInt32(value));
    }
}