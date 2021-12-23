using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS.Models
{
    public partial class Client
    {
        public Client()
        {
            Addresses = new HashSet<Address>();
            Phones = new HashSet<Phone>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? LastName { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
