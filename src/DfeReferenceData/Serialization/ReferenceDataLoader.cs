using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace DfeReferenceData.Serialization;

internal static class ReferenceDataLoader
{
    /// <summary>Reads an embedded JSON file, identified by its path relative to the json directory.</summary>
    public static ReferenceDataDocument<TRecord> Load<TRecord>(
        string path,
        JsonTypeInfo<ReferenceDataDocument<TRecord>> typeInfo)
    {
        using var stream = typeof(ReferenceDataLoader).Assembly.GetManifestResourceStream(path)
            ?? throw new InvalidOperationException($"Reference data '{path}' is not embedded in the assembly.");

        return JsonSerializer.Deserialize(stream, typeInfo)
            ?? throw new InvalidOperationException($"Reference data '{path}' is empty.");
    }
}
