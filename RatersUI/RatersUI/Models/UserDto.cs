using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatersUI.Models
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public int ReviewerId { get; set; }

        //public ReviewerDto Reviewer { get; set; }
    }
}
