using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCP.DTO
{
   public class BillInfo
    {
        private int iD;
        private int iDBill;
        private int drinkID;
        private int count;
        public BillInfo(int iD, int iDBill, int iDDrink, int count)
        {
            this.ID = iD;
            this.BillID = iDBill;
            this.DrinkID = iDDrink;
            this.Count = count;
        }
        public BillInfo(DataRow rows)
        {
            this.ID = (int)rows["id"];
            this.BillID = (int)rows["idBill"];
            this.DrinkID = (int)rows["idDrink"];
            this.Count = (int)rows["count"];
        } 

        public int ID { get => iD; set => iD = value; }
        public int BillID { get => iDBill; set => iDBill = value; }
        public int DrinkID { get => drinkID; set => drinkID = value; }
        public int Count { get => count; set => count = value; }
    }
}
