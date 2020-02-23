using QLCP.DAO;
using QLCP.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace QLCP
{
    public partial class fManagercs : Form
    {
        /// <summary>
        /// Gọi lại các hàm thực thi
        /// </summary>
        public fManagercs()
        {
            InitializeComponent();
            LoadDrink();
            LoadTable();
            LoadCategory();
            LoadComboboxTable(cbSwitchTable);
         

        }

        private void fManagercs_Load(object sender, EventArgs e)
        {}
        /// <summary>
        /// Load tên, giá của nước uống trong Drink, và thực thi câu load này bằng hàm ExcuteQuery được viết bên Dataprovider
        /// </summary>
        void LoadDrink()
        {
            String query = "Select name,Price from Drink";
            dtgvListOfDrink.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        /// <summary>
        /// Lấy danh sách Category trong CategoryDAO và gán vào listCategory kiểu list
        /// Sau đó với mỗi comboBoxCategory sẽ được gán bởi listCategory
        /// Hiển thi cbCategory bằng chính tên của nó bằng lệnh DisplayMember
        /// </summary>
        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";

        }
        /// <summary>
        /// Lấy danh sách nước uống từ DrinkDAO với phương thức GetDrinkByCategoryID, Truyền vào id của category để biết những món nước này thuộc loại id của Category nào
        /// Hiển thi cbDrink bằng chính tên của nó bằng lệnh DisplayMember
        /// </summary>
        /// <param name="id"></param>
        void LoadDrinkListByCategoryID(int id)
        {
            List<Drink> listDrink = DrinkDAO.Instace.GetDrinkByCategoryID(id);
            cbDrink.DataSource = listDrink;
            cbDrink.DisplayMember = "Name";
        }






        private void btnAddMenu_Click(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Tạo biến tablelist mới kiểu trả về là List<table> vì ở file TableDAO.cs hàm của LoadTableList có kiểu trả về là List<table>
        /// For each : Từng item trong cái table này thì chúng ta sẽ 
        /// 1. Tạo cho nó button với chiều dài ,rộng được gán cứng ở file TableDAO.cs
        /// 2.Thêm tên cho từng button và xuống dòng thêm status cho từng button tương ứng
        /// 3.Trong switch case ta xét từng trường hợp status của từng item,nếu item có status trống thì set màu ....,Nếu trường hợp status của item Có người thì set màu ...
        /// 4.flpTable.Control.add có nghĩa là flowlayoutpanel ở tầng GUI sẽ tự add button tương ứng vào
        ///  btn.Click += btn_Click : Tao event show bill cua button table
        /// btn.Tag = item : lay id trong button table
        /// </summary>
        void LoadTable()
        {
            flpTable.Controls.Clear(); // Xoa Table truoc khi load lai
            List<Table> tablelist = TableDAO.Instance.LoadTableList();
            foreach (Table item in tablelist)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.HotPink;
                        break;
                    default:
                    case "Có Người":
                        btn.BackColor = Color.BlueViolet;
                        break;
                }


                flpTable.Controls.Add(btn);
            }
        }
        /// <summary>
        /// lsvBill.Items.Clear : Có chức năng xóa bill sau khi load lại bill của bàn khác
        /// Câu lệnh trong foreach có chức năng thêm item name,count,price,totalPrice vào từng cột trong listViewBill
        /// Cộng TotalPrice trong lsvBill và gán lại cho totalPrice
        /// Sau đó chuyển totalPrice được convert thành String và gán lại thành Text trong textbox TotalPrice trong giao diện
        /// 
        /// CultureInfo dùng để cài đặt dạng của tiền tệ được gán vào biến culture,tiền $ tương ứng với en-US,tiền việt vi-VN
        /// </summary>
        /// <param name="id"></param>
        void showBill(int id)
        {
            lsvBill.Items.Clear();
            List<QLCP.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (QLCP.DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }

            //CultureInfo culture = new CultureInfo("en-US");
            CultureInfo culture = new CultureInfo("vi-VN");


            txbTotalPrice.Text = totalPrice.ToString("c", culture);

        }
        /// <summary>
        /// Hàm này có chức năng show ra danh sách table thông qua class TableDAO + phương thức LoadTableList
        /// Sau đó hiển thị combobox cb bằng thuộc tính Name
        /// </summary>
        /// <param name="cb"></param>
        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";  
        }



        /// <summary>
        /// tableID được lấy ra bằng cách lấy tag = id table
        /// Sau đó lấy ra cái tag của lsvBill để lưu lại giá trị tag của table đó khi thêm món
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            showBill(tableID);
        }

        private void dtgvBillInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvListOfDrink_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lsvBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Khi event này chạy thì nó sẽ chạy hàm LoadDrinkListByCategoryID
        /// sender là kiểu dữ liệu object dùng chung
        /// Tạo comboBox sau đó gán sender có kiểu dữ liệu như comboBox để gán vào comboBox cb..Tránh gây xung đột
        /// </summary>
        /// <param name="sender"></param> Kiểu dữ liệu object
        /// <param name="e"></param> tham số e cũng chứa một đối tượng, nhưng là kiểu cụ thể của một loại các tham số của mouse event, chứa các dữ liệu của event
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Category selected = cb.SelectedItem as Category;
            id = selected.ID;

            LoadDrinkListByCategoryID(id);
        }
        /// <summary>
        /// Ràng buộc : Mỗi một table chỉ có duy nhất tối đa 1 bill chưa check out
        /// Ta lấy lsvBill.Tag as TAble là để lấy cái tag của table đó gán vào table.Chức năng của tag để xác định được đang thao tác trên table nào
        /// Sao đó lấy ra ID của table đó để insert vào dữ liệu. ID của table đó được lấy bằng class BillDAo với phương thức GetUncheckBillIDByTableID
        /// Nếu idBill  == -1 (Lúc này thì table đó chưa có bàn) else la Bill tồn tại
        /// Nếu chưa có idBill thì insertBill và InserBillInfo sẽ được thực thi
        /// Nếu Bill tồn tại thì insert thêm BillInfo nếu khách hàng muốn chọn thêm món 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDrink_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);

            int DrinkID = (cbDrink.SelectedItem as Drink).ID;
            int count = (int)nmDrinkCount.Value;
            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), DrinkID, count);
            }
            else
            {

                BillInfoDAO.Instance.InsertBillInfo(idBill, DrinkID, count);
            }
            showBill(table.ID);
            LoadTable();
        }

        private void btn_Click_1(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Đầu tiên ta lấy ra tag của table
        /// Sau đó lấy ra ID của table để xác định table nào sẽ được check out bằng BillDAO.Instance.GetUncheckBillIDByTableID
        /// Nếu idBill khác -1 , tức là table này có bill....Trước khi thanh toán xuất ra thông báo có muốn thanh toán hóa đơn ko
        /// Sau khi thanh toán thì load lại bill bằng hàm ShowBill
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int discount = (int)nmDisCount.Value;

            double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0]);
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;


            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn {0}\nTổng tiền - (Tổng tiền / 100) x Giảm giá\n=> {1} - ({1} / 100) x {2} = {3}", table.Name, totalPrice, discount, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, discount);
                    showBill(table.ID);

                    LoadTable();
                }
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void txbTotalPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {

            int id1 = (lsvBill.Tag as Table).ID;

            int id2 = (cbSwitchTable.SelectedItem as Table).ID;
            if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển bàn {0} qua bàn {1}", (lsvBill.Tag as Table).Name, (cbSwitchTable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(id1, id2);

                LoadTable();
            }
        }

    }
}
