using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AskDTakeOutDB : BaseDB
    {
        public AskDTakeOutDB() : base("AskDTakeOut") { }
        public List<AskDTakeOut> GetList()
        {
            Select();
            return base.list.Cast<AskDTakeOut>().ToList();
        }
        protected override BaseEntity CreateModel()
        {
            AskDTakeOut item = new AskDTakeOut();
            item.AskCode = Convert.ToInt32(reader["AskCode"]);
            item.DCode =MyDB.DepositsDB.GetDepositsByCode( Convert.ToInt32( reader["DCode"]));
            item.aWhen = Convert.ToDateTime(reader["aWhen"]);
            item.aSum = Convert.ToInt32(reader["aSum"]);
            item.reminders = Convert.ToInt32(reader["reminders"]);
            item.TimeTakeOut = Convert.ToDateTime(reader["TimeTakeOut"]);
            item.TakenOut = Convert.ToBoolean(reader["TakenOut"]);
            return item;
        }
        public AskDTakeOut GetAskDTakeOutByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.AskCode == code);
        }


        protected override BaseEntity EqualsEntity(BaseEntity updatedEntity)
        {
            AskDTakeOut updateItem = (AskDTakeOut)updatedEntity;
            AskDTakeOut item = MyDB.AskDTakeOutDB.GetAskDTakeOutByCode(updateItem.AskCode);
            item.AskCode = updateItem.AskCode;
            item.DCode = updateItem.DCode;
            item.aWhen = updateItem.aWhen;
            item.aSum = updateItem.aSum;
            item.reminders = updateItem.reminders;
            item.TimeTakeOut = updateItem.TimeTakeOut;
            item.TakenOut =updateItem.TakenOut;
            return item;
        }
        public int GetNextKey()
        {
            if (GetList().Count() == 0)
                return 1;
            return GetList().Max(x => x.AskCode) + 1;
        }
    }
}
