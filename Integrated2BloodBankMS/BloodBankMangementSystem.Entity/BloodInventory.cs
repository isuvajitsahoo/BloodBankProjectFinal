using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankMangementSystem.Entity
{
    public class BloodInventory
    {
        public string BloodInvenoryID { get; set; }
        public string BloodGroup { get; set; }
        public int NumberOfBottles { get; set; }
        public string BloodBankID { get; set; }
        public DateTime ExpiryDate { get; set; }        
        
    }
}
