using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS.Models
{
    public partial class Phone
    {
        public int IdClient { get; set; }
        public string PhoneNumber { get; set; } = null!;

        public virtual Client IdClientNavigation { get; set; } = null!;
    }
}
