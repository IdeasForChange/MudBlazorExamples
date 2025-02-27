using Fluxor;

namespace EnterpriseAppFluxor.Features.Dropdowns.Store;

public record ComplexObject
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
}

public record DropdownState
{
    public bool IsLoading { get; init; }
    public IEnumerable<ComplexObject> Items { get; init; } = [];
    public ComplexObject? SelectedItem { get; init; }
}

// Actions
public class LoadDropdownDataAction { }

public record DropdownDataLoadedAction(IEnumerable<ComplexObject> Items);
public record SetSelectedItemAction(ComplexObject SelectedItem);

// Reducers
public static class DropdownReducers
{
    [ReducerMethod]
    public static DropdownState OnDropdownDataLoaded(DropdownState state, DropdownDataLoadedAction action)
    {
        return state with
        {
            Items = action.Items,
            IsLoading = false
        };
    }

    [ReducerMethod]
    public static DropdownState OnSetSelectedItem(DropdownState state, SetSelectedItemAction action)
    {
        return state with
        {
            SelectedItem = action.SelectedItem
        };
    }
}

// Effects
public class DropdownEffects
{
    private readonly IComplexObjectService _service;

    public DropdownEffects(IComplexObjectService service)
    {
        _service = service;
    }

    [EffectMethod]
    public async Task HandleLoadDropdownDataAction(LoadDropdownDataAction action, IDispatcher dispatcher)
    {
        var items = await _service.GetComplexObjectsAsync();
        dispatcher.Dispatch(new DropdownDataLoadedAction(items));
    }
}