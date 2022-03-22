using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace encoding
{

    class data
    {
        public struct expense_detail
        {
            public string expense_id;
            public string expense_date;
            public string paid_to;
            public string summary;
            public int period_id;
            public int paid_id;
            public double amount_paid;
            public bool leisure;

            public expense_detail(string expense_id, string expense_date, string paid_to, string summary, int period_id, int paid_id, double amount_paid, bool leisure)
            {
                this.expense_id = expense_id;
                this.expense_date = expense_date;
                this.paid_to = paid_to;
                this.summary = summary;
                this.period_id = period_id;
                this.paid_id = paid_id;
                this.amount_paid = amount_paid;
                this.leisure = leisure;
            }

        }

        public static List<expense_detail> ReadData(string connectionString, string queryString)
        {
            List<expense_detail> a = new List<expense_detail>();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    a.Add(new expense_detail(
                        Base64Encode(reader[0].ToString()),
                        reader[1].ToString(),
                        Base64Encode(reader[2].ToString()),
                        reader[3].ToString(),
                        int.Parse($"{reader[4]}"),
                        int.Parse($"{reader[5]}"),
                        double.Parse($"{reader[6]}"),
                        bool.Parse($"{reader[7]}")
                        ));
                }
                reader.Close();
            }
            return a;
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText.Trim());
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}


