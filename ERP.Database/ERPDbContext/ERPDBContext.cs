using ERP.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Database.ERPDbContext
{
    public class ERPDBContext : DbContext
    {
        public ERPDBContext(DbContextOptions<ERPDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        property.SetValueConverter(new ValueConverter<DateTime, DateTime>(
                            v => v.Kind == DateTimeKind.Utc ? v : DateTime.SpecifyKind(v, DateTimeKind.Utc),
                            v => DateTime.SpecifyKind(v, DateTimeKind.Utc)));
                    }
                    else if (property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(new ValueConverter<DateTime?, DateTime?>(
                            v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v,
                            v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v));
                    }
                }
            }
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<PurchaseRequest> PurchaseRequests { get; set; }
        public DbSet<PurchaseRequestItems> PurchaseRequestItems { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<PurchaseOrderItems> PurchaseOrderItems { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceItem> InvoiceItem { get; set; }
        public DbSet<ReProperty> ReProperty { get; set; }
        public DbSet<RePropertyHistory> RePropertyHistory { get; set; }
        public DbSet<LandlordHistory> LandlordHistory { get; set; }
        public DbSet<Landlord> Landlord { get; set; }
        public DbSet<ReTenants> ReTenants { get; set; }
        public DbSet<ReCheque> ReCheque { get; set; }
        public DbSet<ReContracts> ReContracts { get; set; }
        public DbSet<REStatus> REStatus { get; set; }
    }
}
