using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Neeman : BaseEntity
    {
        public int nCode { get; set; }
        public string nFirstLastName { get; set; }
        public string nPhone1 { get; set; }
        public string nPhone2 { get; set; }
        public string nCommunity { get; set; }

        public override string[] GetKeyFields()
        {
            return new string[] { "nCode" };
        }

        public override string GetTableName()
        {
            return "Neeman";
        }
    }
}
    

