using BloodBankMangementSystem.DAL;
using BloodBankMangementSystem.Entity;
using BloodBankMangementSystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankMangementSystem.BLL
{
   public class BloodInventoryBLL
    {
        public DataTable BloodInventoryDisplay()
        {
            try
            {
                BloodInventoryDL bid = new BloodInventoryDL();
                return bid.BloodInventoryDisplay();
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
        }

        public bool DeleteBloodInventory(DateTime ExpiryDate)
        {
            try
            {
                BloodInventoryDL bid = new BloodInventoryDL();
                return bid.DeleteBloodInventory(ExpiryDate);
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
        }
        public bool EditBloodInventory(BloodInventory pobj)
        {
            try
            {
                BloodInventoryDL pd = new BloodInventoryDL();
                return pd.EditBloodInventory(pobj);
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
        }

        public DataTable GetAllBloodBankName()
        {
            BloodInventoryDL bid = new BloodInventoryDL();
            return bid.GetAllBloodBankName();
        }

        public BloodInventory Search(int searchInventory)
        {
            try
            {
                BloodInventoryDL pd = new BloodInventoryDL();
                return pd.Search(searchInventory);
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
        }

    }
}

