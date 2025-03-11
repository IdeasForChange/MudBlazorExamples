namespace EnterpriseAppFluxor.Features.AutoRefresh.Store;

public interface IDataService
{
    Task<IEnumerable<DataItem>> GetDataAsync();
}

public class DataService : IDataService
{
    public async Task<IEnumerable<DataItem>> GetDataAsync()
    {
        // Simulate fetching data from an API or database
        await Task.Delay(500); // Simulate network delay

        var random = new Random();

        return new List<DataItem>
        {
            new DataItem { Id = 1, Name = $"Item {random.NextInt64()}" },
            new DataItem { Id = 2, Name = $"Item {random.NextInt64()}" },
            new DataItem { Id = 3, Name = $"Item {random.NextInt64()}" }
        };
    }
}