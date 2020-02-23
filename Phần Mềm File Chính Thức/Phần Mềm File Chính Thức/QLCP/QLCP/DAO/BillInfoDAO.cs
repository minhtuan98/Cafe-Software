using QLCP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCP.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;
      //  private object data;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }

        private BillInfoDAO() { }
        /// <summary>
        /// Tạo một danh sách billInfo được lấy ra từ BillInfo.cs và gán nó vào listBillInfo kiểu list
        /// Sau đó thực thi câu Select , lấy ra BillInfo mà tại đó idBillFo = id của Bill và thực thi bằng class DataProvider với phương thức ExecuteQuery và gán nó lại cho biến data với kiểu DataTable
        /// Với mỗi item trong DataRow của câu lệnh Select bên trên...gán thông tin của item đó vào biến info và gán thông tin biến info vào listBillInfo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BillInfo where idBill= "+ id);

            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);

            }

            return listBillInfo;
        }
        /// <summary>
        /// Chạy Store Proc trong DB kiểm tra xem liệu tạo có thành công không và kiểm tra bằng hàm dataprovider với phương thức ExecuteNonQuery
        /// </summary>
        /// <param name="idBill"></param>
        /// <param name="idDrink"></param>
        /// <param name="count"></param>
        public void InsertBillInfo(int idBill,int idDrink,int count)
        {
            DataProvider.Instance.ExecuteNonQuery("  USP_InsertBillInfo @idBill , @idDrink , @count", new object[] { idBill,idDrink,count});
        }
    }
}
