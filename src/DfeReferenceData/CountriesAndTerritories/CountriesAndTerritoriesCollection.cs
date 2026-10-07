using DfeReferenceData.Serialization;

namespace DfeReferenceData.CountriesAndTerritories;

/// <summary>A mapping of ISO country codes to country names, official names, and citizen names.</summary>
public sealed class CountriesAndTerritoriesCollection : ReferenceDataCollection<CountryOrTerritory>
{
    private const string ResourcePath = "countries_and_territories/countries_and_territories.json";

    private CountriesAndTerritoriesCollection()
        : base(ReferenceDataLoader.Load(ResourcePath, ReferenceDataJsonContext.Default.ReferenceDataDocumentCountryOrTerritory))
    {
    }

    /// <summary>The countries and territories shipped with this library.</summary>
    public static CountriesAndTerritoriesCollection Default { get; } = new();
}
