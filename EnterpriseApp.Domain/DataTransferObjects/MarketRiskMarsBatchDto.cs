using EnterpriseApp.Domain.Enums;

namespace EnterpriseApp.Domain.DataTransferObjects;

public class MarketRiskMarsBatchDto : IEquatable<MarketRiskMarsBatchDto>
{
    public DateTime? AsOfDate { get; set; }
    public string BatchId { get; set; } = string.Empty;
    public BatchType BatchType { get; set; }


    // Implement IEquatable<ComplexObject>
    public bool Equals(MarketRiskMarsBatchDto? other)
    {
        if (other is null) return false;
        return BatchId == other.BatchId; // Use Id for equality comparison
    }

    // Override Equals and GetHashCode for consistency
    public override bool Equals(object? obj)
    {
        return Equals(obj as MarketRiskMarsBatchDto);
    }

    public override int GetHashCode()
    {
        return BatchId.GetHashCode();
    }
}