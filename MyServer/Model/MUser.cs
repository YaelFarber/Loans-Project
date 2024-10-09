using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MUser:BaseEntity
    {
        public string UserID { get; set; }
        public string FirstLastName { get; set; }       
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string uAddress { get; set; }
        public string uMail { get; set; }
        public bool IsNeeman { get; set; }

        public override string[] GetKeyFields()
        {
            return new string[] { "UserID" };
        }

        public override string GetTableName()
        {
            return "MyUser";
        }
    }
}
