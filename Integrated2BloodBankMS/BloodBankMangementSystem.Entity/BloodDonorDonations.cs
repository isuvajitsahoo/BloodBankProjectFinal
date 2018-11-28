using System;

namespace BloodBankMangementSystem.Entity
{
    public class BloodDonorDonations
    {

        public int BloodDonationID { get; set; }
        public string BloodDonorID { get; set; }
        public DateTime BloodDonationDate { get; set; }
        public int NumberOfBottles { get; set; }
        public int Weight { get; set; }
        public decimal HBCount { get; set; }

        public string BloodBankId { get; set; }
        public string BloodGroup { get; set; }

    }
}