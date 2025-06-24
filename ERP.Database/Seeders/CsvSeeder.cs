using CsvHelper;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Database.Seeders
{
    public static class CsvSeeder
    {
        public static void SeedAll(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var provider = scope.ServiceProvider;
            var db = provider.GetRequiredService<IDbConnection>() as IDbConnection;


            var projectRoot = Directory.GetParent(AppContext.BaseDirectory)!
                          .Parent!.Parent!.Parent!.FullName;

            var seedFolder = Path.Combine(projectRoot, "ERP.Database", "SeedData");

            if (!Directory.Exists(seedFolder)) return;

            var csvFiles = Directory.GetFiles(seedFolder, "*.csv");

            foreach (var file in csvFiles)
            {
                var tableName = Path.GetFileNameWithoutExtension(file); // e.g., "Status"
                Console.WriteLine($"Seeding table: {tableName}");

                using var reader = new StreamReader(file);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<dynamic>().ToList();

                foreach (var record in records)
                {
                    var dict = (IDictionary<string, object>)record;
                    var columns = string.Join(", ", dict.Keys);
                    var parameters = string.Join(", ", dict.Keys.Select(k => "@" + k));
                    var updates = string.Join(", ", dict.Keys.Where(k => k.ToLower() != "id").Select(k => $"{k}=EXCLUDED.{k}"));

                    string sql = $@"
                        INSERT INTO {tableName} ({columns})
                        VALUES ({parameters})
                        ON CONFLICT (Id) DO UPDATE SET {updates};";

                    db.Execute(sql, (object)record);
                }
            }
        }
    }
}
