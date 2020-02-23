using QLCP.DAO;
using System;
using System.Windows.Forms;

namespace QLCP
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            String passWord = txbPassWord.Text;
            if (Login(userName, passWord))
            {
                fManagercs f = new fManagercs();
                this.Hide();

                f.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
            }
        }

        public bool Login(string userName, string passWord)
        {
            if (AccountDAO.Instance.Login(userName, passWord))
                return true;
            else
                return false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
