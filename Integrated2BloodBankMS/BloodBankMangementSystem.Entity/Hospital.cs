using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankMangementSystem.Entity
{
    public class Hospital
    {
        public string HospitalID { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public long ContactNo { get; set; }
    }
}
