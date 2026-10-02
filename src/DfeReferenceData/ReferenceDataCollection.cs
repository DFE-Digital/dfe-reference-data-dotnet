using System.Collections;
using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using DfeReferenceData.Serialization;

namespace DfeReferenceData;

/// <summary>An immutable reference data list: its metadata and its records, in source order.</summary>
/// <typeparam name="TRecord">The type of record held by the list.</typeparam>
public abstract class ReferenceDataCollection<TRecord> : IReadOnlyList<TRecord>
    where TRecord : class, IReferenceDataRecord
{
    private readonly IReadOnlyList<TRecord> _records;
    private readonly FrozenDictionary<string, TRecord> _recordsById;

    private protected ReferenceDataCollection(ReferenceDataDocument<TRecord> document)
    {
        Description = document.Description;
        UsageGuidance = document.UsageGuidance;
        DocsUrl = document.DocsUrl;
        FieldDescriptions = document.FieldDescriptions;
        _records = document.Records;
        _recordsById = document.Records.ToFrozenDictionary(record => record.Id, StringComparer.Ordinal);
    }

    /// <summary>A description of the list.</summary>
    public string? Description { get; }

    /// <summary>Guidance on how the list should be used.</summary>
    public string? UsageGuidance { get; }

    /// <summary>The location of the list's documentation.</summary>
    public Uri? DocsUrl { get; }

    /// <summary>Descriptions of the record fields, keyed by the field name used in the source data.</summary>
    public IReadOnlyDictionary<string, string> FieldDescriptions { get; }

    /// <inheritdoc />
    public int Count => _records.Count;

    /// <inheritdoc />
    public TRecord this[int index] => _records[index];

    /// <summary>Returns the record with the given identifier, or <see langword="null"/> if there is none.</summary>
    public TRecord? Find(string id) => _recordsById.GetValueOrDefault(id);

    /// <summary>Gets the record with the given identifier.</summary>
    /// <returns><see langword="true"/> if the record exists; otherwise <see langword="false"/>.</returns>
    public bool TryFind(string id, [MaybeNullWhen(false)] out TRecord record) => _recordsById.TryGetValue(id, out record);

    /// <inheritdoc />
    public IEnumerator<TRecord> GetEnumerator() => _records.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
