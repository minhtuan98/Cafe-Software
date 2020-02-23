using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCP.DTO
{
    public class Drink
    {
        private int iD;
        private string name;
        private int idCategory;
        private float price;

        public Drink(int id, string name, int categoryID, float price)
        {
            this.ID = id;
            this.Name = name;
            this.IdCategory = categoryID;
            this.Price = price;
        }

        public Drink(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.IdCategory = (int)row["idCategory"];
            this.Price = (float)Convert.ToDouble(row[ "price"].ToString());
        }
        

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public float Price { get => price; set => price = value; }
    }
}
