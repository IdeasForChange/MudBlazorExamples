using Fluxor;

namespace EnterpriseAppFluxor.Features.AutoRefresh.Store;

public record DataItem
{
    public int Id { get; init; }
    public string? Name { get; init; }
}

public record DataState
{
    public bool IsLoading { get; init; }
    public IEnumerable<DataItem> Data { get; init; } = new List<DataItem>();
    public DateTime LastUpdated { get; init; }
}

public class DataStateFeature : Feature<DataState>
{
    public override string GetName() => nameof(DataStateFeature);

    protected override DataState GetInitialState()
    {
        return new DataState
        {
            IsLoading = true,
            Data = [],
            LastUpdated = DateTime.Now
        };
    }
}


// Actions
public record FetchDataAction();
public record DataFetchedAction(IEnumerable<DataItem> Data, DateTime LastUpdated);

// Reducer
public static class Reducers
{
    [ReducerMethod]
    public static DataState ReduceFetchDataAction(DataState state, FetchDataAction action) =>
        state with { IsLoading = true };

    [ReducerMethod]
    public static DataState ReduceDataFetchedAction(DataState state, DataFetchedAction action) =>
        state with { IsLoading = false, Data = action.Data, LastUpdated = action.LastUpdated };
}

// EFFECTS
public class Effects
{
    private readonly IDataService _dataService;

    public Effects(IDataService dataService)
    {
        _dataService = dataService;
    }

    [EffectMethod]
    public async Task HandleFetchDataAction(FetchDataAction action, IDispatcher dispatcher)
    {
        var data = await _dataService.GetDataAsync();
        dispatcher.Dispatch(new DataFetchedAction(data, DateTime.UtcNow));
    }
}