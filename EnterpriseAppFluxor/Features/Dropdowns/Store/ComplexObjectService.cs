namespace EnterpriseAppFluxor.Features.Dropdowns.Store;

public class ComplexObjectService : IComplexObjectService
{
    // Simulate an asynchronous data fetch (e.g., from a database or API)
    public async Task<IEnumerable<ComplexObject>> GetComplexObjectsAsync()
    {
        // Simulate a delay to mimic an asynchronous operation
        await Task.Delay(1000);

        // Return a list of complex objects
        return new List<ComplexObject>
        {
            new ComplexObject { Id = 1, Name = "Item 1" },
            new ComplexObject { Id = 2, Name = "Item 2" },
            new ComplexObject { Id = 3, Name = "Item 3" },
            new ComplexObject { Id = 4, Name = "Item 4" },
            new ComplexObject { Id = 5, Name = "Item 5" }
        };
    }
}