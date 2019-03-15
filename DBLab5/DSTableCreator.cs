using System;
using System.Collections.Generic;
using System.Data;

namespace DBLab5
{
    class DSTableCreator
    {
        private static DSTableCreator dSTableCreator;

        private DSTableCreator() { }

        public static DSTableCreator GetInstance()
        {
            if (dSTableCreator == null)
            {
                dSTableCreator = new DSTableCreator();
            }

            return dSTableCreator;
        }

        private DataSet CreateTable()
        {
            DataSet dataSet = new DataSet("PTU");
            DataTable dataTable = new DataTable("Subjects");
            dataSet.Tables.Add(dataTable);
            DataColumn idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
            idColumn.Unique = true;
            idColumn.AllowDBNull = false;
            idColumn.AutoIncrement = true;
            idColumn.AutoIncrementSeed = 1;
            idColumn.AutoIncrementStep = 1;
            DataColumn nameColumn = new DataColumn("Name", Type.GetType("System.String"));
            dataTable.Columns.Add(idColumn);
            dataTable.Columns.Add(nameColumn);
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["Id"] };
            dataTable.Rows.Add(new object[] { null, "Сварка сложных конструкций" });
            dataTable.Rows.Add(new object[] { null, "Механика: общий курс" });
            dataTable.Rows.Add(new object[] { null, "Физическая культура" });
            return dataSet;
        }

        public IEnumerable<string> GetSubjects()
        {
            IList<string> result = new List<string>();
            foreach (DataRow row in CreateTable().Tables["Subjects"].Rows)
            {
                result.Add(row["Name"].ToString());
            }
            return result;
        }
    }
}
