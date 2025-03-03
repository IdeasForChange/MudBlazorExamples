using EnterpriseApp.Domain.DataTransferObjects;
using EnterpriseApp.Domain.Enums;
using EnterpriseApp.Domain.Services;
using Fluxor;

namespace EnterpriseAppFluxor.Features.Globals.Store;

// Aplication State
public record AppState
{
    public DateTime SelectedDate { get; init; } = DateTime.Now.AddDays(-1);
    public List<BatchDto> Batches { get; init; } = new();
    public BatchDto? SelectedBatch { get; init; }
}

// Feature
public class AppStateFeature : Feature<AppState>
{
    public override string GetName() => "AppState";
    protected override AppState GetInitialState()
    {
        return new AppState
        {
            SelectedDate = DateTime.Now.AddDays(-1),
            Batches = [],
            SelectedBatch = null
        };
    }
}

// ACTIONS 
public record SetSelectedDateAction(DateTime SelectedDate);
public record SetBatchesAction(List<BatchDto> Batches);
public record SetSelectedBatchAction(BatchDto? SelectedBatch);

// REDUCERS
public static class Reducers
{
    [ReducerMethod]
    public static AppState OnSetSelectedDate(AppState state, SetSelectedDateAction action) => state with { SelectedDate = action.SelectedDate };

    [ReducerMethod]
    public static AppState OnSetBatches(AppState state, SetBatchesAction action) => state with { Batches = action.Batches };

    [ReducerMethod]
    public static AppState OnSetSelectedBatch(AppState state, SetSelectedBatchAction action) => state with { SelectedBatch = action.SelectedBatch };
}


// EFFECTS
public class Effects(IBatchService batchService)
{
    [EffectMethod]
    public async Task HandleSetSelectedDate(SetSelectedDateAction action, IDispatcher dispatcher)
    {
        // Fetch batches for the selected date
        var batches = await batchService.GetBatchesAsync(action.SelectedDate);
        dispatcher.Dispatch(new SetBatchesAction(batches));

        // Find the "Final" batch
        var finalBatch = batches.FirstOrDefault(b => b.BatchType == BatchType.Final);
        dispatcher.Dispatch(new SetSelectedBatchAction(finalBatch));
    }
}

