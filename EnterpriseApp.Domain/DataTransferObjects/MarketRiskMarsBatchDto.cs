using EnterpriseApp.Domain.Enums;

namespace EnterpriseApp.Domain.DataTransferObjects;

public class MarketRiskMarsBatchDto
{
    public DateTime? AsOfDate { get; set; }
    public string BatchId { get; set; } = string.Empty;
    public BatchType BatchType { get; set; }
}