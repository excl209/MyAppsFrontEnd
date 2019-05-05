using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppsFrontEnd.Models
{
    public class LoggingItems
    {
        [Key]
        public int LogId { get; set; }
        public int AppId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Level { get; set; }
        public string Thread { get; set; }
        public string Class { get; set; }
        public string Message { get; set; }
    }
}
