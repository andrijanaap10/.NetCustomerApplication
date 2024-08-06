using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;

namespace App
{
    public class Class1
    {
        public void GenerateReport()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", $"AgentReport_{DateTime.Now.ToString("yyyyMMdd")}.csv");

            using (SqlConnection con = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=users;Integrated Security=True"))
            {
                con.Open();
                string query = @"
                SELECT 
                    ae.agent_id AS AgentID, 
                    ae.customer_id AS CustomerID, 
                    b.name AS Name, 
                    b.email AS Email, 
                    b.reward AS Reward, 
                    ae.entry_date AS EntryDate
                FROM 
                    AgentEntries ae
                JOIN 
                    byers b ON ae.customer_id = b.customer_id
                WHERE 
                    ae.entry_date >= @StartDate 
                    AND ae.entry_date < @EndDate;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    DateTime startDate = DateTime.Now.AddMonths(-1); 
                    DateTime endDate = DateTime.Now;

                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                        using (StreamWriter writer = new StreamWriter(filePath))
                        {
                            writer.WriteLine("AgentID,CustomerID,Name,Email,Reward,EntryDate");

                            while (reader.Read())
                            {
                                writer.WriteLine($"{reader["AgentID"]},{reader["CustomerID"]},{reader["Name"]},{reader["Email"]},{reader["Reward"]},{reader["EntryDate"]}");
                            }
                        }
                    }
                }
            }
        }
    }



}



