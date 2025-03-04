using EnterpriseApp.Domain.DataTransferObjects;

namespace EnterpriseApp.Domain.Services;

public interface IBatchService
{
    Task<List<BatchDto>> GetBatchesAsync(DateTime selectedDate);
    Task<List<MarketRiskMarsBatchDto>> GetMarsBatchesAsync(DateTime? selectedDate);
}