namespace EnterpriseApp.Domain.Services;

using EnterpriseApp.Domain.DataTransferObjects;
using EnterpriseApp.Domain.Enums;
using EnterpriseApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FakeBatchService : IBatchService
{
    public Task<List<BatchDto>> GetBatchesAsync(DateTime selectedDate)
    {
        // Simulate a delay to mimic an asynchronous operation
        return Task.Delay(500).ContinueWith(_ =>
        {
            // Generate mock data based on the selected date
            var batches = new List<BatchDto>
            {
                new BatchDto
                {
                    BatchId = Guid.NewGuid().ToString(),
                    BatchDate = selectedDate,
                    BatchType = BatchType.Intraday
                },
                new BatchDto
                {
                    BatchId = Guid.NewGuid().ToString(),
                    BatchDate = selectedDate,
                    BatchType = BatchType.Final
                },
                new BatchDto
                {
                    BatchId = Guid.NewGuid().ToString(),
                    BatchDate = selectedDate,
                    BatchType = BatchType.IntradayFlash
                }
            };

            return batches;
        });
    }

    public Task<List<MarketRiskMarsBatchDto>> GetMarsBatchesAsync(DateTime? selectedDate)
    {
        // Simulate a delay to mimic an asynchronous operation
        return Task.Delay(10).ContinueWith(_ =>
        {
            // Generate mock data based on the selected date
            var batches = new List<MarketRiskMarsBatchDto>
            {
                new MarketRiskMarsBatchDto
                {
                    AsOfDate = selectedDate,
                    BatchId = Guid.NewGuid().ToString(),
                    BatchType = BatchType.Intraday
                },
                new MarketRiskMarsBatchDto
                {
                    AsOfDate = selectedDate,
                    BatchId = Guid.NewGuid().ToString(),
                    BatchType = BatchType.Final
                },
                new MarketRiskMarsBatchDto
                {
                    AsOfDate = selectedDate,
                    BatchId = Guid.NewGuid().ToString(),
                    BatchType = BatchType.IntradayFlash
                }
            };

            return batches;
        });
    }

    public Task<List<DataPointX>> GetDataAsync(DateTime? date, string? selectedValue)
    {
        // Simulate a delay to mimic an async data fetch
        return Task.Delay(500).ContinueWith(_ =>
        {
            var random = new Random();
            var dataPoints = new List<DataPointX>();

            // Generate fake data based on the selected date and dropdown value
            for (int i = 0; i < 5; i++)
            {
                dataPoints.Add(new DataPointX
                {
                    Label = $"Item {i + 1} ({selectedValue})",
                    Value = random.Next(10, 100) // Random value between 10 and 100
                });
            }

            return dataPoints;
        });
    }
}
