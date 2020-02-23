using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCP.DTO
{
    public class Menu
    {
        private String foodName;
        private int count;
        private float price;
        private float totalPrice;
        public Menu(string name, int count, float price, float totalPrice = 0)
        {
            this.FoodName = foodName;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }

        public Menu(DataRow row)
        {
            this.FoodName = row["name"].ToString();
            this.Count = (int)row["count"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }

        public string FoodName
        {
            get { return foodName; }
            private set { foodName = value; }
        }
        public int Count
        {
            get { return count; }
            private set { count = value; }
        }
        public float Price
        {
            get { return price; }
            private set { price = value; }
        }
        public float TotalPrice
        {
            get { return totalPrice; }
            private set { totalPrice = value; }
        }
    }
}
