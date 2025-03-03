using EnterpriseApp.Domain.Enums;

namespace EnterpriseApp.Domain.DataTransferObjects;

public class BatchDto
{
    public string BatchId { get; set; } = new Random().Next(100000, 2000000).ToString();
    public DateTime BatchDate { get; set; }
    public BatchType BatchType { get; set; }
}