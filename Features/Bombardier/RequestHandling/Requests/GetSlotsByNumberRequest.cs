using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopAPI.Features.RequestHandling.Base;

namespace ShopAPI.Features.Bombardier.RequestHandling.Requests
{
    public class GetSlotsByNumberRequest : Request<Response>
    {
        public GetSlotsByNumberRequest(int slotNumber)
        {
            SlotNumber = slotNumber;
        }
        public int SlotNumber { get; set; }
    }
}
