using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class NeemanDB:BaseDB
    {
        public NeemanDB() : base("Neeman") { }
        public List<Neeman> GetList()
        {
            Select();
            return base.list.Cast<Neeman>().ToList();
        }


        protected override BaseEntity CreateModel()
        {
            Neeman item = new Neeman();
            item.nCode = Convert.ToInt32(reader["nCode"]);
            item.nFirstLastName = reader["nFirstLastName"].ToString();
            item.nPhone1 =reader["nPhone1"].ToString();
            item.nPhone2 = reader["nPhone2"].ToString();
            item.nCommunity = reader["nCommunity"].ToString();
         

            return item;
        }
        public Neeman GetNeemanByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.nCode == code);
        }

        protected override BaseEntity EqualsEntity(BaseEntity updatedEntity)
        {
            Neeman updateItem = (Neeman)updatedEntity;
            Neeman item = MyDB.NeemanDB.GetNeemanByCode(updateItem.nCode);
            item.nCode = updateItem.nCode;
            item.nFirstLastName = updateItem.nFirstLastName;
            item.nPhone1 = updateItem.nPhone1;
            item.nPhone2 = updateItem.nPhone2;
            item.nCommunity= updateItem.nCommunity;
            return item;
        }
        public int GetNextKey()
        {
            if (GetList().Count() == 0)
                return 1;
            return GetList().Max(x => x.nCode) + 1;
        }
    }
}
