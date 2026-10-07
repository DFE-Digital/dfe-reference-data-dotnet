using DfeReferenceData.CountriesAndTerritories;

namespace DfeReferenceData.Tests.CountriesAndTerritories;

public class CountriesAndTerritoriesCollectionTests
{
    private readonly CountriesAndTerritoriesCollection _countriesAndTerritories = CountriesAndTerritoriesCollection.Default;

    [Fact]
    public void Exposes_list_metadata()
    {
        Assert.Equal(
            "A mapping of ISO country codes to country names, official names, and citizen names.",
            _countriesAndTerritories.Description);
        Assert.Null(_countriesAndTerritories.UsageGuidance);
        Assert.NotNull(_countriesAndTerritories.DocsUrl);
        Assert.Equal("The country ISO code", _countriesAndTerritories.FieldDescriptions["id"]);
    }

    [Fact]
    public void Reads_records_in_source_order()
    {
        Assert.Equal(220, _countriesAndTerritories.Count);

        var first = _countriesAndTerritories[0];
        Assert.Equal("AF", first.Id);
        Assert.Equal("Afghanistan", first.Name);
        Assert.Equal("The Islamic Republic of Afghanistan", first.OfficialName);
        Assert.Equal("Afghan", first.CitizenNames);
    }

    [Fact]
    public void Finds_a_record_by_iso_code()
    {
        var unitedKingdom = _countriesAndTerritories.Find("GB");

        Assert.NotNull(unitedKingdom);
        Assert.Equal("United Kingdom", unitedKingdom.Name);
        Assert.Equal("The United Kingdom of Great Britain and Northern Ireland", unitedKingdom.OfficialName);
        Assert.Equal("Briton, British", unitedKingdom.CitizenNames);
    }

    [Fact]
    public void Returns_null_for_an_unknown_iso_code()
    {
        Assert.Null(_countriesAndTerritories.Find("unknown"));
        Assert.False(_countriesAndTerritories.TryFind("unknown", out _));
    }
}
