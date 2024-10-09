using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public abstract class BaseDB
    {
        protected string connectionString;
        protected OleDbConnection connection;
        protected OleDbCommand command;
        protected OleDbDataReader reader;

        protected List<BaseEntity> list;

        protected List<BaseEntity> inserted = new List<BaseEntity>();
        protected List<BaseEntity> changed = new List<BaseEntity>();
        protected List<BaseEntity> deleted = new List<BaseEntity>();

        public BaseDB(string tableName)
        {//Provider=Microsoft.Jet.OLEDB.4.0;Data Source="E:\דוגמה למודל\ServerPrj\Data\LendingEquipment.mdb"
            connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;;Data Source=" + GetCurrentPath() + @"Data\\ChesedYaakov.mdb");
            command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from " + tableName;
            list = new List<BaseEntity>();

        }
        public string GetCurrentPath()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string[] arr = path.Split('\\');
            path = "";
            for (int i = 0; i < arr.Length - 3; i++)
            {
                path += arr[i] + "\\";
            }
            return path;
        }
        protected abstract BaseEntity CreateModel();
        protected abstract BaseEntity EqualsEntity(BaseEntity updatedEntity);

        protected void Select()
        {
            if (list.Count() == 0)
            {
                List<BaseEntity> lst = new List<BaseEntity>();
                //try
                //{
                    connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(CreateModel());
                }
            }
            //        catch (Exception ex) { }
            //finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            //}

        }
        
        public void Add(BaseEntity item)
        {
            if (item != null)
            {
                inserted.Add(item);
                list.Add(item);
            }
        }
        public void Update(BaseEntity item)
        {
            if (item != null)
            {
                BaseEntity toUpdate = EqualsEntity(item);
                changed.Add(toUpdate);
            }
        }
        public void Delete(BaseEntity item)
        {
            if (item != null)
            {
                BaseEntity toDelete = EqualsEntity(item);
                deleted.Add(item);
            }
        }
        public int SaveChanges()
        {
            int records = 0;
            try
            {
                command.Connection = connection;
                connection.Open();
                foreach (var item in inserted)
                {
                    command.CommandText = SQLBuilder.InsertSQL(item);
                    records += command.ExecuteNonQuery();

                }
                inserted.Clear();
                foreach (var item in changed)
                {
                    command.CommandText = SQLBuilder.UpdateSQL(item);
                    records += command.ExecuteNonQuery();
                }
                changed.Clear();
                foreach (var item in deleted)
                {
                    command.CommandText = SQLBuilder.DeleteSQL(item);
                    records += command.ExecuteNonQuery();
                    list.Remove(item);
                }
                deleted.Clear();
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message + "\nDataBase:" + command.CommandText);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

            return records;
        }


        public virtual int GetNextKey()
        {
            return 1;
        }
    }
}
