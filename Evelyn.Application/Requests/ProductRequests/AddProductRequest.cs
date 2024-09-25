using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evelyn.Application.Requests.ProductRequests
{
    public class AddProductRequest
    {
        public string ProductSerial { get; set; }
        public string ProductModel { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public int ProjectId { get; set; }
    }
}