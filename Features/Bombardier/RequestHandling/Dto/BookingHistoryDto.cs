using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAPI.Features.Bombardier.RequestHandling.Dto
{
    public class BookingHistoryDto
    {
        public int Amount { get; set; }

        public Guid BookingId { get; set; }

        public Guid ItemId { get; set; }

        public string Status { get; set; }

        public long Timestamp { get; set; }
    }
}
