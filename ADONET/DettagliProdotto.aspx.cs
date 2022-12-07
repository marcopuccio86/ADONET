using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static ADONET.Default;

namespace ADONET
{
    public partial class DettagliProdotto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string idProdotto = Request.QueryString["idProdotto"];

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStringSampleEcommerce"].ToString();
                con.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = $"SELECT * FROM PRODOTTI WHERE idProdotto = {idProdotto}";
                command.Connection = con;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lblNomeProdotto.Text = reader["NomeProdotto"].ToString();
                       lblDescrizioneProdotto.Text = reader["DescrizioneProdotto"].ToString();
                        lblPrezzoProdotto.Text = Convert.ToDecimal(reader["Prezzo"]).ToString("c2");
                    }
                }

              
                con.Close();
            }
            catch (Exception ex)
            {
                
            }

        }
    }
}