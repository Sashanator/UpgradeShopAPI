using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAPI.Features.Bombardier.RequestHandling.Dto
{
    public class OrderDto
    {
        public DeliveryInfo DeliveryDuration { get; set; }

        public Guid Id { get; set; }

        public List<PaymentInfo> PaymentHistory { get; set; }
    }

    public class DeliveryInfo
    {
        public int Nano { get; set; }

        public bool Negative { get; set; }

        public long Seconds { get; set; }

        public Unit Units { get; set; }
        
        public bool Zero { get; set; }
    }

    public class Unit
    {
        public bool DateBased { get; set; }

        public bool DurationEstimated { get; set; }

        public bool TimeBased { get; set; }
    }

    public class PaymentInfo
    {
        public int Amount { get; set; }

        public string Status { get; set; }

        public long Timestamp { get; set; }

        public Guid TransactionId { get; set; }
    }
}
