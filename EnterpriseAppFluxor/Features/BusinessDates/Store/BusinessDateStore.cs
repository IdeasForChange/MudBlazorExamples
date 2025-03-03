using Fluxor;

namespace EnterpriseAppFluxor.Features.BusinessDates.Store;

// Define the Immutable State
public record BusinessDateState
{
    public DateTime? SelectedBusinessDate { get; init; }
}

// Feature Details 
public class BusinessDateFeature : Feature<BusinessDateState>
{
    public override string GetName() => nameof(BusinessDateFeature);

    protected override BusinessDateState GetInitialState()
    {
        return new BusinessDateState
        {
            SelectedBusinessDate = DateTime.Now.AddDays(-1)
        };
    }
}

// All Actions that are allowed for Business Date
public record SetSelectedBusinessDateAction(DateTime? BusinessDate);

// Reducers
public static class BusinessDateReducers
{
    [ReducerMethod]
    public static BusinessDateState OnSetSelectedBusinessDateAction(BusinessDateState state, SetSelectedBusinessDateAction action)
    {
        return state with { SelectedBusinessDate = action.BusinessDate };
    }
}
