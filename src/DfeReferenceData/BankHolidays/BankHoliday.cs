using System.Text.Json.Serialization;
using DfeReferenceData.Serialization;

namespace DfeReferenceData.BankHolidays;

/// <summary>A bank holiday in England and Wales.</summary>
public sealed record BankHoliday : IReferenceDataRecord
{
    /// <summary>A unique identifier.</summary>
    public required string Id { get; init; }

    /// <summary>The title of the bank holiday.</summary>
    public required string Title { get; init; }

    /// <summary>The date of the bank holiday.</summary>
    [JsonConverter(typeof(DateOnlyFromDateTimeConverter))]
    public required DateOnly Date { get; init; }

    /// <summary>Notes about the bank holiday.</summary>
    public string? Notes { get; init; }
}
