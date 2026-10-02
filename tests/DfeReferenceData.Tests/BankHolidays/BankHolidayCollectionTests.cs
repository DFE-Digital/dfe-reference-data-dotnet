using DfeReferenceData.BankHolidays;

namespace DfeReferenceData.Tests.BankHolidays;

public class BankHolidayCollectionTests
{
    private readonly BankHolidayCollection _bankHolidays = BankHolidayCollection.Default;

    [Fact]
    public void Exposes_list_metadata()
    {
        Assert.Equal("Bank Holidays(England and Wales)", _bankHolidays.Description);
        Assert.Null(_bankHolidays.UsageGuidance);
        Assert.NotNull(_bankHolidays.DocsUrl);
        Assert.Equal("The title of the bank holiday", _bankHolidays.FieldDescriptions["title"]);
    }

    [Fact]
    public void Reads_records_in_source_order()
    {
        Assert.NotEmpty(_bankHolidays);

        var first = _bankHolidays[0];
        Assert.Equal("05d80311-f177-4a7a-b538-214cae5a830f", first.Id);
        Assert.Equal("New Year’s Day", first.Title);
        Assert.Equal(new DateOnly(2019, 1, 1), first.Date);
        Assert.Null(first.Notes);
    }

    [Fact]
    public void Finds_a_record_by_id()
    {
        var boxingDay = _bankHolidays.Find("271cc54b-93ce-4edc-8598-1e5ada3e913f");

        Assert.NotNull(boxingDay);
        Assert.Equal(new DateOnly(2020, 12, 28), boxingDay.Date);
        Assert.Equal("Substitute day", boxingDay.Notes);
    }

    [Fact]
    public void Returns_null_for_an_unknown_id()
    {
        Assert.Null(_bankHolidays.Find("unknown"));
        Assert.False(_bankHolidays.TryFind("unknown", out _));
    }

    [Fact]
    public void Knows_whether_a_date_is_a_bank_holiday()
    {
        Assert.True(_bankHolidays.IsBankHoliday(new DateOnly(2026, 12, 25)));
        Assert.False(_bankHolidays.IsBankHoliday(new DateOnly(2026, 12, 24)));
    }

    [Fact]
    public void Filters_by_year()
    {
        var bankHolidays = _bankHolidays.InYear(2022).ToList();

        Assert.Equal(10, bankHolidays.Count);
        Assert.All(bankHolidays, bankHoliday => Assert.Equal(2022, bankHoliday.Date.Year));
    }
}
