using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.Entities.Models.Dto
{
    public class ProductItemDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int PurchasePrice { get; set; }
        public int SalesPrice { get; set; }
        public int CoverPrice { get; set; }
        public int ProductStock { get; set; }
    }
}
