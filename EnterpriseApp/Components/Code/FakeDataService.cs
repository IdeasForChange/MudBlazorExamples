namespace EnterpriseApp.Components.Code;

public class FakeDataService
{
    public Task<List<DataPoint>> GetDataAsync(DateTime? date, string? selectedValue)
    {
        // Simulate a delay to mimic an async data fetch
        return Task.Delay(500).ContinueWith(_ =>
        {
            var random = new Random();
            var dataPoints = new List<DataPoint>();

            // Generate fake data based on the selected date and dropdown value
            for (int i = 0; i < 5; i++)
            {
                dataPoints.Add(new DataPoint
                {
                    Label = $"Item {i + 1} ({selectedValue})",
                    Value = random.Next(10, 100) // Random value between 10 and 100
                });
            }

            return dataPoints;
        });
    }
}