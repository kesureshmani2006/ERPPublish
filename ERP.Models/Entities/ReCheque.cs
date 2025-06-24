using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Entities
{
    public class ReCheque
    {
        [Key]
        public int Id { get; set; }
        public string ChequeNo { get; set; }
        public string BankName { get; set; }
        public DateTimeOffset ChequeDate { get; set; }
        public double ChequeAmount { get; set; } = 0;
        public string? Remarks { get; set; }
        public string ChqStatus {  get; set; }
        [ForeignKey("ReTenants")]
        public long TenantId { get; set; }
        [ForeignKey("ReContracts")]
        public long ContractId { get;set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }


}

