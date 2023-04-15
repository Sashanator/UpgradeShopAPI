using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopAPI.Features.Bombardier.RequestHandling.Dto;

namespace ShopAPI.Features.Bombardier.Services;

public class BombardierService : IBombardierService
{ // TODO: Rework dummy data
    public async Task<BookingHistoryDto> GetBookingProduct(Guid bookingId, CancellationToken cancellationToken)
    {
        return new BookingHistoryDto
        {
            Amount = 1,
            BookingId = bookingId,
            ItemId = Guid.NewGuid(),
            Status = "FAILED",
            Timestamp = 0
        };
    }

    public async Task<List<HistoryDto>> GetHistory(Guid orderId, CancellationToken cancellationToken)
    {
        return new List<HistoryDto>
        {
            new()
            {
                Attempts = 0,
                Outcome = "EXPIRED",
                SubmissionStartedTime = 0,
                SubmittedTime = 0,
                TransactionId = Guid.NewGuid(),
                preparedTime = 0
            }
        };
    }

    public async Task<List<int>> GetSlots(CancellationToken cancellationToken)
    {
        var result = new List<int>();
        for (int i = 0; i < 25; i++)
        {
            result.Add(i + 1);
        }

        return result;
    }

    public async Task<List<int>> GetSlots(int slotNumber, CancellationToken cancellationToken)
    {
        var result = new List<int>();
        for (int i = 0; i < slotNumber; i++)
        {
            result.Add(i + 1);
        }

        return result;
    }

    public async Task<List<PayLogDto>> GetPayLog(Guid orderId, CancellationToken cancellationToken)
    {
        return new List<PayLogDto>
        {
            new()
            {
                Timestamp = 0,
                Amount = 0,
                OrderId = Guid.NewGuid(),
                PaymentTransactionId = Guid.NewGuid(),
                Type = "REFUND"
            }
        };
    }

    public async Task<List<ItemDto>> GetItems(Guid orderId, CancellationToken cancellationToken)
    {
        return new List<ItemDto>
        {
            new()
            {
                Amount = 0,
                Id = orderId,
                Description = "Hello, World",
                Price = 0,
                Title = "Hello, I am Sasha Ssorin!"
            }
        };
    }

    public async Task MakeOrder(CancellationToken cancellationToken)
    {
        
    }

    public async Task<OrderDto> GetOrderById(Guid orderId, CancellationToken cancellationToken)
    {
        return new OrderDto
        {
            Id = Guid.NewGuid(),
            DeliveryDuration = new DeliveryInfo
            {
                Nano = 0,
                Negative = false,
                Seconds = 0,
                Units = new Unit
                {
                    DateBased = false,
                    DurationEstimated = false,
                    TimeBased = false
                },
                Zero = false
            },
            PaymentHistory = new List<PaymentInfo>
            {
                new()
                {
                    Amount = 0,
                    Timestamp = 0,
                    Status = "FAILED",
                    TransactionId = Guid.NewGuid()
                }
            }
        };
    }

    public async Task<BookingDto> GetBookings(Guid orderId, CancellationToken cancellationToken)
    {
        return new BookingDto
        {
            Id = orderId,
            FailedItems = new List<Guid>
            {
                Guid.NewGuid()
            }
        };
    }

    public async Task<BookingDto> SetTime(Guid orderId, int slotNumber, CancellationToken cancellationToken)
    {
        return new BookingDto
        {
            Id = orderId,
            FailedItems = new List<Guid>
            {
                Guid.NewGuid()
            }
        };
    }

    public async Task<bool> PutItem(int amount, Guid itemId, Guid orderId, CancellationToken cancellationToken)
    {
        return true;
    }

    public async Task<PayDto> Pay(Guid orderId, CancellationToken cancellationToken)
    {
        return new PayDto
        {
            Timestamp = 0,
            TransactionId = Guid.NewGuid()
        };
    }
}