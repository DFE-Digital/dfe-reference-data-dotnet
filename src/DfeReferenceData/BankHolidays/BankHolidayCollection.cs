using System.Collections.Frozen;
using DfeReferenceData.Serialization;

namespace DfeReferenceData.BankHolidays;

/// <summary>The bank holidays of England and Wales.</summary>
public sealed class BankHolidayCollection : ReferenceDataCollection<BankHoliday>
{
    private const string ResourcePath = "bank_holidays/bank_holidays.json";

    private readonly FrozenSet<DateOnly> _dates;

    private BankHolidayCollection()
        : base(ReferenceDataLoader.Load(ResourcePath, ReferenceDataJsonContext.Default.ReferenceDataDocumentBankHoliday))
    {
        _dates = this.Select(bankHoliday => bankHoliday.Date).ToFrozenSet();
    }

    /// <summary>The bank holidays shipped with this library.</summary>
    public static BankHolidayCollection Default { get; } = new();

    /// <summary>Whether the given date is a bank holiday.</summary>
    public bool IsBankHoliday(DateOnly date) => _dates.Contains(date);

    /// <summary>The bank holidays falling in the given calendar year.</summary>
    public IEnumerable<BankHoliday> InYear(int year) => this.Where(bankHoliday => bankHoliday.Date.Year == year);
}
