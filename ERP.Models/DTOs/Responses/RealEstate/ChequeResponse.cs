using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.DTOs.Responses.RealEstate
{
    public class ChequeResponse
    {
        public long Id { get; set; }
        public string ChequeNumber { get; set; }
        public string BankName { get; set; }
        public DateTimeOffset ChequeDate { get; set; }
        public double ChequeAmount { get; set; } = 0;
        public string Status { get; set; }
        public long TenantId { get; set; }
        public long ContractId { get; set; }
    }
}
