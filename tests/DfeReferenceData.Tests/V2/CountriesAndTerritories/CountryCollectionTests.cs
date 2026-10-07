using DfeReferenceData.V2.CountriesAndTerritories;

namespace DfeReferenceData.Tests.V2.CountriesAndTerritories;

public class CountryCollectionTests
{
    private readonly CountryCollection _countries = CountryCollection.Default;

    [Fact]
    public void Exposes_list_metadata()
    {
        Assert.Equal(
            "A mapping of ISO country codes to country names, official names, and citizen names.",
            _countries.Description);
        Assert.Null(_countries.UsageGuidance);
        Assert.NotNull(_countries.DocsUrl);
        Assert.Equal("The country ISO code", _countries.FieldDescriptions["id"]);
    }

    [Fact]
    public void Reads_records_in_source_order()
    {
        Assert.Equal(196, _countries.Count);

        var first = _countries[0];
        Assert.Equal("AF", first.Id);
        Assert.Equal("Afghanistan", first.Name);
        Assert.Equal("The Islamic Republic of Afghanistan", first.OfficialName);
        Assert.Equal("Afghan", first.CitizenNames);
    }

    [Fact]
    public void Finds_a_record_by_iso_code()
    {
        var unitedKingdom = _countries.Find("GB");

        Assert.NotNull(unitedKingdom);
        Assert.Equal("United Kingdom", unitedKingdom.Name);
        Assert.Equal("The United Kingdom of Great Britain and Northern Ireland", unitedKingdom.OfficialName);
        Assert.Equal("Briton, British", unitedKingdom.CitizenNames);
    }

    [Fact]
    public void Returns_null_for_an_unknown_iso_code()
    {
        Assert.Null(_countries.Find("unknown"));
        Assert.False(_countries.TryFind("unknown", out _));
    }
}
