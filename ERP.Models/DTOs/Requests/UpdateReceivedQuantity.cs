using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Requests
{
    public class UpdateReceivedQuantity
    {
        public string PONumber { get; set; }
        public List<ReceivedQuantityList> ReceivedQuantityLists { get; set; }
    }
    public class ReceivedQuantityList
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
