using EnterpriseApp.Domain.DataTransferObjects;
using EnterpriseApp.Domain.Services;
using EnterpriseAppFluxor.Features.Dropdowns.Store;
using Fluxor;

namespace EnterpriseAppFluxor.Features.MarsBatches.Store;

// Define the Object's immutable State
public record MarsBatchState
{
    public bool IsLoading { get; set; }
    public MarketRiskMarsBatchDto? SelectedMarsBatch { get; set; }
    public List<MarketRiskMarsBatchDto> MarsBatches { get; set; } = [];
}

// Featue 
public class MarsBatchStateFeature : Feature<MarsBatchState>
{
    public override string GetName() => nameof(MarsBatchState);

    protected override MarsBatchState GetInitialState()
    {
        return new MarsBatchState()
        {
            IsLoading = false,
            SelectedMarsBatch = null,
            MarsBatches = []
        };
    }
}

// Actions
public record SetSelectedMarsBatchAction(MarketRiskMarsBatchDto? MarsBatch);
public record FetchMarsBatchesAction(DateTime? SelectedBusinessDate);
public record SetMarsBatchesAction(List<MarketRiskMarsBatchDto> MarsBatches);


// Reducers
public static class MarsBatchReducers
{
    [ReducerMethod]
    public static MarsBatchState OnSetSelectedMarsBatchAction(MarsBatchState state, SetSelectedMarsBatchAction action)
    {
        return state with
        {
            SelectedMarsBatch = action.MarsBatch
        };
    }

    [ReducerMethod]
    public static MarsBatchState OnSetMarsBatchesAction(MarsBatchState state, SetMarsBatchesAction action)
    {
        return state with
        {
            MarsBatches = action.MarsBatches
        };
    }
}

// Effects 
public class MarsBatchEffects(IBatchService service)
{
    [EffectMethod]
    public async Task HandleFetchMarsBatchesAction(FetchMarsBatchesAction action, IDispatcher dispatcher)
    {
        var items = await service.GetMarsBatchesAsync(action.SelectedBusinessDate);
        dispatcher.Dispatch(new SetMarsBatchesAction(items));

        var selectedItem = items.First();
        dispatcher.Dispatch(new SetSelectedMarsBatchAction(selectedItem));
    }
}
