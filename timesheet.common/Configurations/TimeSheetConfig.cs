using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timesheet.common.Configurations
{
    public class TimeSheetConfig
    {

        public string ConnectionString { get; set; }

        public static TimeSheetConfig LoadTimeSheetConfig()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return builder.GetRequiredSection("TimeSheetConfig").Get<TimeSheetConfig>();
        }
    }
}
