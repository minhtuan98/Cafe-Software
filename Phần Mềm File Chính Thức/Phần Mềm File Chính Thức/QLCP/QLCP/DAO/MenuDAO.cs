using QLCP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms (Không thể sử dụng cùng lúc dòng using này và dòng using QLCP.DTO, Menu nằm trong Menu.cs của DTO)
namespace QLCP.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }

        private MenuDAO() { }
        /// <summary>
        /// Tạo ra một danh sách lấy dữ liệu từ Menu(của DTO) có tên listMenu
        /// Thực thi câu Query bằng hàm ExcecuteQuery từ class DataProvider và select ra name,count,price,totalPrice (count*price)
        /// Tạo một bảng dữ liệu có tên data và gán dữ liệu bao gồm name,count,price,totalPrice vào biến data
        /// Với mỗi 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listMenu = new List<Menu>();
            string query = "  SELECT d.name,bi.count,d.price,bi.count* d.price AS TotalPrice FROM dbo.BillInfo AS bi,dbo.Bill AS b, dbo.Drink AS d WHERE bi.idBill = b.id AND bi.idDrink = d.id AND b.status = 0 AND b.idTable =" + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
