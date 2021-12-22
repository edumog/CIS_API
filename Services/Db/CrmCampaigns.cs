using CIS.DTOs;
using CIS.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS.Db
{
    public class CrmCampaigns: ICrmCampaignDb
    {
        string connectionString = @"Data Source=DESKTOP-T6PJIPS\SQLEXPRESS;Initial Catalog=CMR;Integrated Security=True";

        string getQuery = @"SELECT [id],
        [name],
        [creationDate]
        FROM[dbo].[campaigns]
        ORDER BY creationDate desc";

        public IList<CrmCampaignDTO> GetCrmCampaigns()
        {
            DataTable result;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(getQuery, conn))
                {
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    conn.Open();
                    DataSet campaigns = new DataSet();
                    adapter.Fill(campaigns, "campaigns");
                    result = campaigns.Tables["campaigns"];
                }
            }
            return (from campaign in result.AsEnumerable()
                                                select new CrmCampaignDTO
                                                {
                                                    Id = campaign.ItemArray[0].ToString(),
                                                    Name = campaign.ItemArray[1].ToString(),
                                                    CreationDate = campaign.ItemArray[2].ToString(),
                                                }).ToList();
        }
    }
}
