namespace DfeReferenceData.Serialization;

/// <summary>The shape shared by every exported JSON file: list metadata plus its records.</summary>
internal sealed record ReferenceDataDocument<TRecord>
{
    public string? Description { get; init; }

    public string? UsageGuidance { get; init; }

    public Uri? DocsUrl { get; init; }

    public IReadOnlyDictionary<string, string> FieldDescriptions { get; init; } = new Dictionary<string, string>();

    public required IReadOnlyList<TRecord> Records { get; init; }
}
