using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
  public  class DonationDB:BaseDB
    {
        public DonationDB() : base("Donation") { }
        public List<Donation> GetList()
        {
            Select();
            return base.list.Cast<Donation>().ToList();
        }


        protected override BaseEntity CreateModel()
        {
            Donation item = new Donation();
            item.dCode = Convert.ToInt32(reader["dCode"]);
            item.Donor = reader["Donor"].ToString();
            item.dSum = Convert.ToInt32(reader["dSum"]);
            item.BankNum = reader["BankNum"].ToString();
            item.BankName = reader["BankName"].ToString();
            item.dDate = Convert.ToDateTime(reader["dDate"]);
            
            return item;
        }
        public Donation GetDonationByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.dCode == code);
        }

        protected override BaseEntity EqualsEntity(BaseEntity updatedEntity)
        {
            Donation updateItem = (Donation)updatedEntity;
            Donation item = MyDB.DonationDB.GetDonationByCode(updateItem.dCode);
            item.dCode = updateItem.dCode;
            item.Donor = updateItem.Donor;
            item.dSum = updateItem.dSum;
            item.BankNum = updateItem.BankNum;
            item.BankName = updateItem.BankName;
            item.dDate = updateItem.dDate;
            return item;
        }
        public int GetNextKey()
        {
            if (GetList().Count() == 0)
                return 1;
            return GetList().Max(x => x.dCode) + 1;
        }
    }
}
