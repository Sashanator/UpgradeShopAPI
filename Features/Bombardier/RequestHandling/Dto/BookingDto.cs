using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAPI.Features.Bombardier.RequestHandling.Dto
{
    public class BookingDto
    {
        public List<Guid> FailedItems { get; set; }

        public Guid Id { get; set; }
    }
}
