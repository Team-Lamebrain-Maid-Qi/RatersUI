using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatersUI.Models
{
    class ReviewDto
    {
        public decimal Rating { get; set; }
        public string Review { get; set; }
        public int BusinessId { get; set; }
        public int ReviewerId { get; set; }
        public ReviewerDto Reviewer { get; set; }
    }
}
