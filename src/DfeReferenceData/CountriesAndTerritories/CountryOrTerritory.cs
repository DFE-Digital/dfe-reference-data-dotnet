namespace DfeReferenceData.CountriesAndTerritories;

/// <summary>A country or territory, identified by its ISO code.</summary>
public sealed record CountryOrTerritory : IReferenceDataRecord
{
    /// <summary>The country ISO code.</summary>
    public required string Id { get; init; }

    /// <summary>The human-readable name of the country.</summary>
    public required string Name { get; init; }

    /// <summary>The human-readable full ‘official name’. Used when the formal version of a country’s name is needed.</summary>
    public required string OfficialName { get; init; }

    /// <summary>
    /// The human-readable citizen names. They are not the legal names for the citizen,
    /// and do not relate to the citizen’s ethnicity.
    /// </summary>
    public string? CitizenNames { get; init; }
}
