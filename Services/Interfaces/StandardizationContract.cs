using CIS.DTOs;
using CIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS.Interfaces
{
    public interface StandardizationContract
    {
        IList<Client> GetClients(StandardizationParameters options);
    }
}
