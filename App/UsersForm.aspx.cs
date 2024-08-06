using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using App.com.crcind.www;
using App.Controller;
using System.Net;
using System.Text.RegularExpressions;

namespace App
{
    public partial class UsersForm : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            lblIDError.Text = "";
            lblNameError.Text = "";
            lblPhoneError.Text = "";
            lblEmailError.Text = "";

         
            if (txtName.Text.Length < 2)
            {
                lblNameError.Text = "Ime i prezime moraju imati najmanje 2 karaktera.";
                isValid = false;
            }

            if (!Regex.IsMatch(txtPhone.Text, @"^\d{10,12}$"))
            {
                lblPhoneError.Text = "Broj telefona mora imati između 10 i 12 cifara.";
                isValid = false;
            }
            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                lblEmailError.Text = "Email mora sadržavati znak @ i tačku.";
                isValid = false;
            }

            if (!isValid)
            {
                return;
            }

            int agentId = Convert.ToInt32(Session["agent_id"]);
            DateTime entryDate = DateTime.Now.Date;

            using (SqlConnection con = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=users;Integrated Security=True"))
            {
                con.Open();

                string checkQuery = "SELECT COUNT(*) FROM AgentEntries WHERE agent_id = @AgentId AND entry_date = @EntryDate";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@AgentId", agentId);
                    checkCmd.Parameters.AddWithValue("@EntryDate", entryDate);

                    int entryCount = (int)checkCmd.ExecuteScalar();
                    if (entryCount >= 5)
                    {
                        lblNameError.Text = "Prekoračili ste dnevni limit od 5 unosa.";
                        return;
                    }
                }

                string insertByersQuery = "INSERT INTO byers (customer_id, name, email, phone, reward) VALUES (@CustomerId, @Name, @Email, @Phone, @Reward)";
                using (SqlCommand insertByersCmd = new SqlCommand(insertByersQuery, con))
                {
                    insertByersCmd.Parameters.AddWithValue("@CustomerId", customerId);
                    insertByersCmd.Parameters.AddWithValue("@Name", txtName.Text);
                    insertByersCmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    insertByersCmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    insertByersCmd.Parameters.AddWithValue("@Reward", DropDownList1.SelectedItem.ToString());

                    int byersResult = insertByersCmd.ExecuteNonQuery();
                    if (byersResult > 0)
                    {
                        string insertAgentEntriesQuery = "INSERT INTO AgentEntries (agent_id, entry_date, customer_id) VALUES (@AgentId, @EntryDate, @CustomerId)";
                        using (SqlCommand insertAgentEntriesCmd = new SqlCommand(insertAgentEntriesQuery, con))
                        {
                            insertAgentEntriesCmd.Parameters.AddWithValue("@AgentId", agentId);
                            insertAgentEntriesCmd.Parameters.AddWithValue("@EntryDate", entryDate);
                            insertAgentEntriesCmd.Parameters.AddWithValue("@CustomerId", customerId);

                            int agentEntriesResult = insertAgentEntriesCmd.ExecuteNonQuery();
                            if (agentEntriesResult > 0)
                            {
                                Response.Write("<script type='text/javascript'>alert('Unos je uspešno sačuvan.')</script>");
                            }
                            else
                            {
                                lblNameError.Text = "Došlo je do greške prilikom unosa u tabelu AgentEntries.";
                            }
                        }
                    }
                    else
                    {
                        lblNameError.Text = "Došlo je do greške prilikom unosa u tabelu byers.";
                    }
                }
            }
        }



        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            Class1 reportGenerator = new Class1();
            reportGenerator.GenerateReport();

            Response.Write("<script>alert('Report generated successfully!');</script>");
        }

        protected async void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            var id = txtSearchID.Text;

            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    var client = new HttpClient();
                    var response = await client.GetAsync($"https://localhost:44332/api/soapclient/find/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine("Response JSON: " + jsonString);
       
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Person>(jsonString);

                        txtID.Text = id;
                        txtName.Text = result?.Name ?? "Nema podataka";
                    }
                    else
                    {
                        txtName.Text = "Nema podataka";
                        Debug.WriteLine($"Response status: {response.StatusCode}");
                        Debug.WriteLine("Response content: " + await response.Content.ReadAsStringAsync());
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    Debug.WriteLine("HttpRequestException: " + httpEx.Message);
                    txtName.Text = "Greška u pretrazi";
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception: " + ex.Message);
                    txtName.Text = "Greška u pretrazi";
                }
            }
        }




    }
}

