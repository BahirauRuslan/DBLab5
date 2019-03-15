using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DBLab5
{
    class DBSubjects
    {
        private static string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;
Initial Catalog=EducationalDepartment;Integrated Security=True";

        private static DBSubjects dBSubjects;

        private DBSubjects() { }

        public static DBSubjects GetInstance()
        {
            if (dBSubjects == null)
            {
                dBSubjects = new DBSubjects();
            }

            return dBSubjects;
        }

        public IEnumerable<string> GetAllSubjects()
        {
            IList<string> subjects = new List<string>();
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Subjects", connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Subjects");
            foreach (DataRow row in dataSet.Tables["Subjects"].Rows)
            {
                subjects.Add(row["Name"].ToString());
            }
            return subjects;
        }
    }
}
