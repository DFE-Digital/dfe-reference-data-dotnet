using System.Text.Json.Serialization;
using DfeReferenceData.BankHolidays;
using DfeReferenceData.CountriesAndTerritories;
using DfeReferenceData.V2.CountriesAndTerritories;

namespace DfeReferenceData.Serialization;

/// <summary>Source-generated serialization metadata. Each reference data list registers its document type here.</summary>
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower)]
[JsonSerializable(typeof(ReferenceDataDocument<BankHoliday>))]
[JsonSerializable(typeof(ReferenceDataDocument<CountryOrTerritory>))]
[JsonSerializable(typeof(ReferenceDataDocument<Country>))]
internal sealed partial class ReferenceDataJsonContext : JsonSerializerContext;
