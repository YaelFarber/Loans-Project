using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public static class SQLBuilder
    {


        public static string InsertSQL(BaseEntity entity)
        {
            Type type = entity.GetType();
            string command = "Insert Into " + entity.GetTableName() + " (";
            string values = " Values (";
            foreach (var item in type.GetProperties())
            {
                string n = item.Name;
                var value = item.GetValue(entity);
                if (value is BaseEntity)
                {
                    string k = ((BaseEntity)value).GetKeyFields()[0];
                    value = value.GetType().GetProperty(k).GetValue(value);
                }

                if (value is string  )
                {
                    command += n + " ,";
                    values += "'" + value + "', ";
                }
                if (value is DateTime)
                {
                    command += n + " ,";
                    values += "#" + ((DateTime)value).ToString("dd/MM/yyyy") + "# , ";
                }

                if (value is int || value is double || value is bool)
                {
                    command += n + " ,";
                    values += value + " , ";
                }
            }
            command = command.Substring(0, command.Length - 2) + ")";
            values = values.Substring(0, values.Length - 2) + ")";
            return command + values;
        }

        public static string UpdateSQL(BaseEntity entity)
        {
            Type type = entity.GetType();
            string command = "Update " + entity.GetTableName() + " set ";
            foreach (var item in type.GetProperties())
            {
                if (entity.GetKeyFields()[0] != item.Name)
                {
                    string n = item.Name;
                    var value = item.GetValue(entity);
                    if (value is BaseEntity)
                    {
                        string k = ((BaseEntity)value).GetKeyFields()[0];//שם המפתח הראשי
                        command += n + "=" + value.GetType().GetProperty(k).GetValue(value) + ", ";
                    }
                    if (value is string)
                        command += n + " = '" + value + "', ";
                    if (value is int || value is double || value is bool)
                        command += n + " = " + value + ", ";
                    if (value is DateTime)
                        command += n + " = #" + ((DateTime)value).ToShortDateString() + "# ,";
                    if (value is TimeSpan)
                        command += n + " = '" + ((TimeSpan)value).ToString("hh") + ":" + ((TimeSpan)value).ToString("mm") + "' ,";

                }
            }
            string where = "";
            foreach (var item in entity.GetKeyFields())
            {
                if (where != "")
                    where += " And ";
                if (entity.GetType().GetProperty(item).GetValue(entity) is string)
                    where += item + " = '" + entity.GetType().GetProperty(item).GetValue(entity) + "' ";
                else
                    where += item + " = " + entity.GetType().GetProperty(item).GetValue(entity);
            }

            command = command.Substring(0, command.Length - 2) + " Where " + where;
            return command;
        }
        public static string DeleteSQL(BaseEntity entity)
        {
            Type type = entity.GetType();
            string command = "Delete From " + entity.GetTableName() + " Where ";

            string where = "";
            foreach (var item in entity.GetKeyFields())
            {
                if (where != "")
                    where += " And ";
                if (entity.GetType().GetProperty(item).GetValue(entity) is string)
                {
                    where += item + " = '" + entity.GetType().GetProperty(item).GetValue(entity) + "' ";
                }
                else
                    where += item + " = " + entity.GetType().GetProperty(item).GetValue(entity);

            }

            command += where;
            return command;
        }

    }
}
