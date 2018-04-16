using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DapperQueryBuilder
{
    public class QueryBuilder
    {
        public static string GetInsertQuery(object entity)
        {
            var tableInfo = GetTableInfo(entity);

            var query = CreateInsertQuery(tableInfo);

            return query;
        }

        private static TableInfo GetTableInfo(object entity)
        {
            TableInfo table = new TableInfo();

            foreach (var attribute in entity.GetType().GetCustomAttributes(true))
            {
                if (attribute is TableAttribute tblAtt)
                {
                    table.TableName = tblAtt.Name;
                    table.Schema = tblAtt.Schema;
                }
            }

            string propertyName = string.Empty;

            List<string> columns = new List<string>();

            foreach (var prop in entity.GetType().GetProperties())
            {
                propertyName = prop.Name;

                foreach (var attribute in prop.GetCustomAttributes(true))
                {
                    if (attribute is ColumnAttribute columnAttribute)
                    {
                        propertyName = columnAttribute.Name;
                    }
                }

                columns.Add(propertyName);
            }

            table.Columns = columns;

            return table;
        }

        public static string CreateInsertQuery(TableInfo table)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder values = new StringBuilder();

            /*
             INSERT [Example].[Products](Id, Name)
             VALUES(@Id, @Name) 
             */

            sb.AppendFormat("INSERT INTO [{0}].[{1}]", table.Schema, table.TableName);

            for (int i = 0; i < table.Columns.Count; i++)
            {
                var column = table.Columns[i];


                if (i == 0)
                {
                    sb.AppendFormat("({0},", column);

                    values.AppendFormat("VALUES(@{0},", column);
                }
                else
                {
                    sb.AppendFormat(" {0}", column);

                    values.AppendFormat(" @{0}", column);

                    if (i == table.Columns.Count - 1)
                    {
                        sb.Append(") ");
                        values.Append(")");
                    }
                    else
                    {
                        sb.Append(",");
                        values.Append(",");
                    }
                }
            }

            sb.Append(values);

            return sb.ToString();
        }
    }
}
