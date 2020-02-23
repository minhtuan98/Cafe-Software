using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QLCP.DAO
{
    public class DataProvider
    {/// <summary>
     /// connectionSTR là liên kết từ Project tới DB
     /// Sử dụng static để đảm bảo không có class nào khác truy cập vào để tạo thêm Singleton
     /// </summary>
     /// 
        private static DataProvider instance; 

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        private String connectionSTR = @"Data Source=DESKTOP-R3KK1UA\SQLEXPRESS1;Initial Catalog=QLCF;Integrated Security=True";

        /// <summary>
        /// using: Sau khi kết thúc khối lệnh nằm trong using thì dữ liệu được giải phóng
        /// </summary>
        /// <param name="query"></param> Dùng để khai báo câu lệnh để thao tác ở DB
        /// <param name="parameter"></param> Dùng để chưa object của dữ liệu trả về từ DB
        /// <returns></returns> Trả về dữ liệu sau khi gọi hàm ExecuteQuery và giá trị được gán vào parameter với kiểu Object[]
        /// 

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
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
        /// Hàm này có chức năng kiểm tra xem câu thực thi có thành công hay không và xuất ra số dòng thành công thay vì xuất ra bảng như hàm ExecuteQuery
        /// data : Số dòng thành công
        /// </summary>
        /// <param name="query"></param> Dùng để khai báo câu lệnh để thao tác ở DB
        /// <param name="parameter"></param> 
        /// <returns></returns>

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
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
        /// Hàm này để xuất ra số lượng giống như Select Count * trong DB
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
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


