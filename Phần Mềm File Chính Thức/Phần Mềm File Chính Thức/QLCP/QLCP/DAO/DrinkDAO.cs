using QLCP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using QLCP.DTO;

namespace QLCP.DAO
{
    public class DrinkDAO
    {
        private static DrinkDAO instace;

        public static DrinkDAO Instace
        {
            get { if (instace == null) instace = new DrinkDAO(); return DrinkDAO.instace; }
            private set { instace = value; }
        }
        private DrinkDAO() { }

        public List<Drink> GetDrinkByCategoryID(int id)
        {
            List<Drink> list = new List<Drink>();
            string query = "SELECT* FROM dbo.Drink where idCategory =" + id;

           DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Drink drink = new Drink(item);
                list.Add(drink);
            }
            return list;
        }

    }
}
