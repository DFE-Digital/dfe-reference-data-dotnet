using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DfeReferenceData.Serialization;

/// <summary>Reads dates that were exported as midnight timestamps, e.g. <c>2019-01-01T00:00:00+00:00</c>.</summary>
internal sealed class DateOnlyFromDateTimeConverter : JsonConverter<DateOnly>
{
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        DateOnly.FromDateTime(reader.GetDateTimeOffset().Date);

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString("O", CultureInfo.InvariantCulture));
}
