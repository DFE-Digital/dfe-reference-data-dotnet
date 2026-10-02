namespace DfeReferenceData;

/// <summary>A single record in a reference data list.</summary>
public interface IReferenceDataRecord
{
    /// <summary>The unique identifier of the record within its list.</summary>
    string Id { get; }
}
