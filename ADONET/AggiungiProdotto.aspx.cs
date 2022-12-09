using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADONET
{
    public partial class AggiungiProdotto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStringSampleEcommerce"].ToString();
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM CATEGORIA";
                command.Connection = connection;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListItem l = new ListItem(reader["NomeCategoria"].ToString(), reader["IdCategoria"].ToString());
                        ddpCategoria.Items.Add(l);
                        RadioButtonList1.Items.Add(l);
                    }
                }
                connection.Close();
            }
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStringSampleEcommerce"].ToString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "InsertNewProdotto";
            command.Connection = connection;

            command.Parameters.AddWithValue("Nome", txtNome.Text);
            command.Parameters.AddWithValue("Prezzo", txtPrezzo.Text);
            command.Parameters.AddWithValue("Promozione", ckcInPromozione.Checked);
            command.Parameters.AddWithValue("idCategoria", ddpCategoria.SelectedValue);

            int row = command.ExecuteNonQuery();
            connection.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStringSampleEcommerce"].ToString();
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "ShowProductsByidCategoria";
            command.Connection = connection;

            command.Parameters.AddWithValue("idCat", RadioButtonList1.SelectedValue);

            SqlDataReader reader = command.ExecuteReader();
            List<Prodotto> lisaProdotti = new List<Prodotto>();    

            while(reader.Read())
            {
                Prodotto p = new Prodotto()
                {
                    NomeProdotto = reader["NomeProdotto"].ToString(),
                    Prezzo = Convert.ToDecimal(reader["Prezzo"])
                };

                lisaProdotti.Add(p);
            }

            GridView1.DataSource= lisaProdotti;
            GridView1.DataBind();

        }
    }

    public class Categoria
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


}