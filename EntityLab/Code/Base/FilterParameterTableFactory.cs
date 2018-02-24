using System;
using System.Collections.Generic;
using System.Data;

namespace EntityLab.Code.Base
{
    public class FilterParameterTableFactory
    {
        public static DataTable MakeTable(FilterParameter[] parameters)
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn { ColumnName = "Value", DataType = Type.GetType("System.String") });
            table.Columns.Add(new DataColumn { ColumnName = "Type", DataType = Type.GetType("System.Int32") });

            foreach (FilterParameter filter in parameters)
            {
                DataRow row = table.NewRow();
                row["Value"] = filter.Value;
                row["Type"] = filter.Type;
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
