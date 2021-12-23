using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS.DTOs
{
    public partial class StandardizationParameters
    {
        public string ColumnDelimiter { get; set; }
        public string RowDelimiter { get; set; }
        public string[] NameComposition { get; set; }
        public string[] LastNameComposition { get; set; }
        public string[] PhoneNumbers { get; set; }
        public string? PhoneDelimiter { get; set; }
        public string[] Addresses { get; set; }
        public string? AddressDelimiter { get; set; }
        public IFormFile File { get; set; }
    }
}
