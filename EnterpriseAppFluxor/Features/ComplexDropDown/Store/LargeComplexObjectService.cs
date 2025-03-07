using EnterpriseApp.Domain.Enums;

namespace EnterpriseAppFluxor.Features.ComplexDropDown.Store;

public class LargeComplexObjectService : ILargeComplexObjectService
{
    // Simulate an asynchronous data fetch (e.g., from a database or API)
    public async Task<IList<LargeComplexObject>> GetComplexObjectsAsync(DateTime? selectedDate)
    {
        // Simulate a delay to mimic an asynchronous operation
        await Task.Delay(1000);

        // Return a list of complex objects with 10 properties
        return new List<LargeComplexObject>
        {
            new LargeComplexObject
            {
                BatchId = 1,
                Name = "Item 1",
                BatchType = BatchType.IntradayFlash,
                BatchDate = selectedDate,
                Property1 = "Value 1",
                Property2 = "Value 2",
                Property3 = "Value 3",
                Property4 = "Value 4",
                Property5 = "Value 5",
                Property6 = "Value 6",
                Property7 = "Value 7",
                Property8 = "Value 8"
            },
            new LargeComplexObject
            {
                BatchId = 2,
                Name = "Item 2",
                BatchType = BatchType.Intraday,
                BatchDate = selectedDate,
                Property1 = "Value 1",
                Property2 = "Value 2",
                Property3 = "Value 3",
                Property4 = "Value 4",
                Property5 = "Value 5",
                Property6 = "Value 6",
                Property7 = "Value 7",
                Property8 = "Value 8"
            },
            new LargeComplexObject
            {
                BatchId = 3,
                Name = "Item 3",
                BatchDate = selectedDate,
                BatchType = BatchType.Final,
                Property1 = "Value 1",
                Property2 = "Value 2",
                Property3 = "Value 3",
                Property4 = "Value 4",
                Property5 = "Value 5",
                Property6 = "Value 6",
                Property7 = "Value 7",
                Property8 = "Value 8"
            }
        };
    }
}