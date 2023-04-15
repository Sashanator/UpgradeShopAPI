using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAPI.Features.Bombardier.RequestHandling.Dto
{
    public class PayDto
    {
        public long Timestamp { get; set; }

        public Guid TransactionId { get; set; }
    }
}
