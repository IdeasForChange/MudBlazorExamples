using EnterpriseAppFluxor.Features.Globals.Store;

namespace EnterpriseAppFluxor.Components.Code;

public interface IBatchService
{
    Task<List<BatchDto>> GetBatchesAsync(DateTime selectedDate);
}