using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AskDTakeOut : BaseEntity
    {
        public int AskCode { get; set; }
        public Deposits DCode { get; set; }
        public DateTime aWhen { get; set; }
        public int aSum { get; set; }
        public int reminders { get; set; }
        public DateTime TimeTakeOut { get; set; }
        public bool TakenOut { get; set; }

        public override string[] GetKeyFields()
        {
            return new string[] { "AskCode" };
        }

        public override string GetTableName()
        {
            return "AskDTakeOut";
        }
    }
}
