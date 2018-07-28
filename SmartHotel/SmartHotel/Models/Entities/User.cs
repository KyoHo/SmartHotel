using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHotel.Models.Entities
{
    class User
    {

        public string UIID { get; set; }

        public string UserName { get; set; }
       
        public string Password { get; set; }

        public string Token { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public int gender { get; set; }

        public DateTime BirthDay { get; set; }

    }
}
