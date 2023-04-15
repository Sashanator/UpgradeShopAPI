using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAPI.Features.Bombardier.RequestHandling.Dto
{
    public class PayLogDto
    {
        public int Amount { get; set; }

        public Guid OrderId { get; set; }

        public Guid PaymentTransactionId { get; set; }

        public long Timestamp { get; set; }

        public string Type { get; set; }
    }
}
