using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Requests.RealEstate
{
    public class AddChequeRequest
    {
        public string ChequeNumber { get; set; }
        public string BankName { get; set; }
        public DateTimeOffset ChequeDate { get; set; }
        public double ChequeAmount { get; set; } = 0;
        public string Status { get; set; }
        public long TenantId { get; set; }
        public long ContractId { get; set; }
        public string? Remarks { get; set; }
    }
}
