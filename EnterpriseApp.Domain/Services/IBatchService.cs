using EnterpriseApp.Domain.DataTransferObjects;
using EnterpriseApp.Domain.Models;

namespace EnterpriseApp.Domain.Services;

public interface IBatchService
{
    Task<List<BatchDto>> GetBatchesAsync(DateTime selectedDate);
    Task<List<MarketRiskMarsBatchDto>> GetMarsBatchesAsync(DateTime? selectedDate);

    Task<List<DataPointX>> GetDataAsync(DateTime? date, string? selectedValue);
}