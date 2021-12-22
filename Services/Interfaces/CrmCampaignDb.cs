using CIS.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS.Interfaces
{
    public interface ICrmCampaignDb
    {
        IList<CrmCampaignDTO> GetCrmCampaigns();
    }
}
