using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsClubWeb.ViewModels
{
   
    public class MemberViewModel
    {
        public long Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Birth Date")]
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }

        [DisplayName("Stret Address")]
        public string StreetAddress { get; set; }
        [DisplayName("Street Number")]
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZIP { get; set; }
    }
}
