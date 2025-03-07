using EnterpriseApp.Domain.Enums;
using EnterpriseAppFluxor.Features.BusinessDates.Store;
using Fluxor;

namespace EnterpriseAppFluxor.Features.ComplexDropDown.Store;

public record DropDownState
{
    public bool IsLoading { get; init; }
    public IEnumerable<LargeComplexObject>? Items { get; init; }
    public LargeComplexObject? SelectedItem { get; init; }
}


public class DropDownStateFeature : Feature<DropDownState>
{
    public override string GetName() => nameof(DropDownStateFeature);

    protected override DropDownState GetInitialState()
    {
        return new DropDownState()
        {
            IsLoading = false,
            Items = null,
            SelectedItem = null
        };
    }
}

public record LoadDropDownDataAction();
public record DropDownDataLoadedAction(IEnumerable<LargeComplexObject>? Items);
public record SetSelectedItemAction(LargeComplexObject? SelectedItem);
public record SetSelectedDateAction(DateTime? SelectedDate);

public static class DropDownReducers
{
    [ReducerMethod]
    public static DropDownState OnDropDownDataLoaded(DropDownState state, DropDownDataLoadedAction action)
    {
        return state with
        {
            Items = action.Items,
            IsLoading = false
        };
    }

    [ReducerMethod]
    public static DropDownState OnSetSelectedItem(DropDownState state, SetSelectedItemAction action)
    {
        return state with
        {
            SelectedItem = action.SelectedItem
        };
    }

    [ReducerMethod]
    public static DropDownState OnSetSelectedDate(DropDownState state, SetSelectedDateAction action)
    {
        // When a date is selected, reset the selected item to a predefined value
        var predefinedItem = state.Items?.FirstOrDefault(x => x.BatchType == BatchType.Final); // Example: Default to the first item
        return state with
        {
            SelectedItem = predefinedItem
        };
    }
}

// Effects
public class DropDownEffects(ILargeComplexObjectService service, IState<BusinessDateState> businessDateState)
{
    [EffectMethod]
    public async Task HandleLoadDropDownDataAction(LoadDropDownDataAction action, IDispatcher dispatcher)
    {
        var items = await service.GetComplexObjectsAsync(businessDateState.Value.SelectedBusinessDate);
        dispatcher.Dispatch(new DropDownDataLoadedAction(items));

        if (items.Any())
        {
            var selectedItem = items.FirstOrDefault(x => x.BatchType == BatchType.Final); // Example: Default to the first item
            dispatcher.Dispatch(new SetSelectedItemAction(selectedItem));
        }
    }
}