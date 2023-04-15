using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopAPI.Features.Bombardier.RequestHandling.Dto;

namespace ShopAPI.Features.Bombardier.Services;

public interface IBombardierService
{
    Task<BookingHistoryDto> GetBookingProduct(Guid bookingId, CancellationToken cancellationToken);

    Task<List<HistoryDto>> GetHistory(Guid orderId, CancellationToken cancellationToken);

    Task<List<int>> GetSlots(CancellationToken cancellationToken);

    Task<List<int>> GetSlots(int slotNumber, CancellationToken cancellationToken);

    Task<List<PayLogDto>> GetPayLog(Guid orderId, CancellationToken cancellationToken);

    Task<List<ItemDto>> GetItems(Guid orderId, CancellationToken cancellationToken);

    Task MakeOrder(CancellationToken cancellationToken);

    Task<OrderDto> GetOrderById(Guid orderId, CancellationToken cancellationToken);

    Task<BookingDto> GetBookings(Guid orderId, CancellationToken cancellationToken);

    Task<BookingDto> SetTime(Guid orderId, int slotNumber, CancellationToken cancellationToken);

    Task<bool> PutItem(int amount, Guid itemId, Guid orderId, CancellationToken cancellationToken);

    Task<PayDto> Pay(Guid orderId, CancellationToken cancellationToken);
}