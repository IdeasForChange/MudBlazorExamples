namespace EnterpriseApp.Domain.Services;

using EnterpriseApp.Domain.DataTransferObjects;
using EnterpriseApp.Domain.Enums;
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
}
