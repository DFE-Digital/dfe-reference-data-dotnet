using System.Text.Json.Serialization;
using DfeReferenceData.BankHolidays;

namespace DfeReferenceData.Serialization;

/// <summary>Source-generated serialization metadata. Each reference data list registers its document type here.</summary>
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower)]
[JsonSerializable(typeof(ReferenceDataDocument<BankHoliday>))]
internal sealed partial class ReferenceDataJsonContext : JsonSerializerContext;
