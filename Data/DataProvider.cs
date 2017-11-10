using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlythuvien.Data
{
    public class DataProvider
    {
        public static string connectionString = "Data Source=.\\DATA1;Initial Catalog=QUANLYTHUVIEN_DATA;Integrated Security=True";
        /// <summary>
        /// Hàm excute 1 query trả về một dataTable chứa các bản ghi thỏa mãn
        /// </summary>
        /// <param name="query">query string truyền vào</param>
        /// <param name="parameter">Mảng các parameter truyền vào</param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(string query,object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter!=null)
                {
                    string[] listParams = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParams)
                    {
                        if (item.StartsWith("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        /// <summary>
        /// Hàm excute 1 nonquery trả về giá trị nguyên
        /// </summary>
        /// <param name="query">query string truyền vào</param>
        /// <param name="parameter">Mảng các parameter truyền vào</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listParams = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParams)
                    {
                        if (item.StartsWith("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
        /// <summary>
        /// Hàm excute 1 query trả về 1 object
        /// </summary>
        /// <param name="query">query string truyền vào</param>
        /// <param name="parameter">Mảng các parameter truyền vào</param>
        /// <returns></returns>
        public static Object ExecuteScalar(string query, object[] parameter = null)
        {
            Object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listParams = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParams)
                    {
                        if (item.StartsWith("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}
