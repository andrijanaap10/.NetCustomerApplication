using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App
{
    public partial class LoginForm : System.Web.UI.Page
    {
       
            protected void Page_Load(object sender, EventArgs e)
            {
                if (Session["agent_id"] != null)
                {
                    Response.Redirect("UsersForm.aspx");
                }
            }

            protected void Page_LoadComplete(object sender, EventArgs e)
            {
                if (Session["agent_id"] != null)
                {
                    Response.Redirect("UsersForm.aspx");
                }
            }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text; 
            string password = txtPass.Text;

            using (SqlConnection con = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=users;Integrated Security=True"))
            {
                con.Open();
                string query = "SELECT agent_id FROM Agents WHERE username = @Username AND password = @Password";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        int agentId = Convert.ToInt32(result);
   
                        Session["agent_id"] = agentId;

                        Response.Redirect("UsersForm.aspx");
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('Neispravno korisničko ime ili lozinka.')</script>");
                    }
                }
            }
        }


    }
}

