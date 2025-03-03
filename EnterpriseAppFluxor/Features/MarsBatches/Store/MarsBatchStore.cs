using EnterpriseApp.Domain.DataTransferObjects;
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



// Reducers
public static class marsBatchReducers
{
    [ReducerMethod]
    public static MarsBatchState OnSetSelectedMarsBatchAction(MarsBatchState state, SetSelectedMarsBatchAction action)
    {
        return state with
        {
            SelectedMarsBatch = action.MarsBatch
        };
    }
}

// Effeccts 
