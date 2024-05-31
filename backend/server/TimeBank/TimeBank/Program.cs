using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeBank
{
    //זה השינוי הגדול מס 2
    public class Program
    {
     
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
// dotnet ef dbcontext scaffold "Server=DESKTOP-EODP1E7\SQLEXPRESS;Database=TimeBank;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -f

