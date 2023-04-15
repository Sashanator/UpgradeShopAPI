using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAPI.Features.Bombardier.RequestHandling.Dto
{
    public class HistoryDto
    {
        public int Attempts { get; set; }

        public string Outcome { get; set; }

        public long preparedTime { get; set; }

        public long SubmissionStartedTime { get; set; }

        public long SubmittedTime { get; set; }

        public Guid TransactionId { get; set; }
    }
}
