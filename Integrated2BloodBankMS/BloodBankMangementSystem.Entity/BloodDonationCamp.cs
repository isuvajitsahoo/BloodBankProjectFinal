using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankMangementSystem.Entity
{
    public class BloodDonationCamp
    {
        public string BloodDonationCampId { get; set; }
        public string CampName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string BloodBankId { get; set; }
        public DateTime CampStartDate { get; set; }
        public DateTime CampEndDate { get; set; }
    }
}
