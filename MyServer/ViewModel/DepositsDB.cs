using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class DepositsDB : BaseDB
    {
        public DepositsDB() : base("Deposits") { }
        public List<Deposits> GetList()
        {
            Select();
            return base.list.Cast<Deposits>().ToList();
        }
        protected override BaseEntity CreateModel()
        {
            Deposits item = new Deposits();
            item.DepositCode = Convert.ToInt32(reader["DepositCode"]);
            item.Deposit = MyDB.UserDB.GetUserByCode(reader["Deposit"].ToString());
            item.DepositSum = Convert.ToInt32(reader["DepositSum"]);
            item.dTime = Convert.ToDateTime(reader["dTime"]);          
            return item;
        }
        public Deposits GetDepositsByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.DepositCode == code);
        }
        protected override BaseEntity EqualsEntity(BaseEntity updatedEntity)
        {
            Deposits updateItem = (Deposits)updatedEntity;
            Deposits item = MyDB.DepositsDB.GetDepositsByCode(updateItem.DepositCode);
            item.DepositCode = updateItem.DepositCode;
            item.Deposit = updateItem.Deposit;
            item.DepositSum = updateItem.DepositSum;
            item.dTime = updateItem.dTime;
            return item;
        }
        public int GetNextKey()
        {
            if (GetList().Count() == 0)
                return 1;
            return GetList().Max(x => x.DepositCode) + 1;
        }
    }
}
