using DfeReferenceData.Serialization;

namespace DfeReferenceData.V2.CountriesAndTerritories;

/// <summary>A mapping of ISO country codes to country names, official names, and citizen names.</summary>
public sealed class CountryCollection : ReferenceDataCollection<Country>
{
    private const string ResourcePath = "v2/countries_and_territories/countries.json";

    private CountryCollection()
        : base(ReferenceDataLoader.Load(ResourcePath, ReferenceDataJsonContext.Default.ReferenceDataDocumentCountry))
    {
    }

    /// <summary>The countries shipped with this library.</summary>
    public static CountryCollection Default { get; } = new();
}
