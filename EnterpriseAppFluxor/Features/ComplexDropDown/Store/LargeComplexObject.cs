using EnterpriseApp.Domain.Enums;

namespace EnterpriseAppFluxor.Features.ComplexDropDown.Store;

public class LargeComplexObject : IEquatable<LargeComplexObject>
{
    public int BatchId { get; init; }
    public string Name { get; init; }
    public DateTime? BatchDate { get; init; }
    public BatchType BatchType { get; init; }
    public string Property1 { get; init; }
    public string Property2 { get; init; }
    public string Property3 { get; init; }
    public string Property4 { get; init; }
    public string Property5 { get; init; }
    public string Property6 { get; init; }
    public string Property7 { get; init; }
    public string Property8 { get; init; }


    // Implement IEquatable<ComplexObject>
    public bool Equals(LargeComplexObject? other)
    {
        if (other is null) return false;
        return BatchId == other.BatchId; // Use Id for equality comparison
    }

    // Override Equals and GetHashCode for consistency
    public override bool Equals(object? obj)
    {
        return Equals(obj as LargeComplexObject);
    }

    public override int GetHashCode()
    {
        return BatchId.GetHashCode();
    }
}