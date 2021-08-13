using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatersUI.Models
{
    public class ReviewerDto
    {
        public int Id { get; set; }

        public string First { get; set; }

        public string Last { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        //public ReviewerDto(UserDto user)
        //{
        //    UserName = user.UserName;
        //    Id = user.ReviewerId;
        //}
    }
}
