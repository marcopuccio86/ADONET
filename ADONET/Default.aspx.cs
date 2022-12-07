using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADONET
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStringSampleEcommerce"].ToString();
                con.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "INSERT INTO Clienti VALUES ('Marco', 'Puccio')";
                command.Connection = con;
                int row = command.ExecuteNonQuery();

                if (row > 0)
                {
                    Label1.Text = "Inserimento effettuato correttamente";
                }
                else
                {
                    Label1.Text = "Inserimento non effettuato";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
                Label1.ForeColor = Color.Red;
            }
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStringSampleEcommerce"].ToString();
                con.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "UPDATE Clienti SET Nome='Luca', Cognome='Senatore' WHERE idCliente=2";
                command.Connection = con;
                int row = command.ExecuteNonQuery();

                if (row > 0)
                {
                    Label1.Text = "Aggiornamento effettuato correttamente";
                }
                else
                {
                    Label1.Text = "Aggiornamento non effettuato";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
                Label1.ForeColor = Color.Red;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStringSampleEcommerce"].ToString();
                con.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "DELETE FROM CLIENTI WHERE idCliente=2";
                command.Connection = con;
                int row = command.ExecuteNonQuery();

                if (row > 0)
                {
                    Label1.Text = "Eliminazione effettuata correttamente";
                }
                else
                {
                    Label1.Text = "Eliminazione non effettuato";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
                Label1.ForeColor = Color.Red;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStringSampleEcommerce"].ToString();
                con.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM PRODOTTI";
                command.Connection = con;

                SqlDataReader reader = command.ExecuteReader();

                List<Prodotto> listaProdotti = new List<Prodotto>(); 

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Prodotto p = new Prodotto();
                        p.IdProdotto = Convert.ToInt32(reader["idProdotto"]);
                        p.NomeProdotto = reader["NomeProdotto"].ToString();
                        p.DescrizioneProdotto= reader["DescrizioneProdotto"].ToString();
                        p.Prezzo= Convert.ToDecimal(reader["Prezzo"]);
                        listaProdotti.Add(p);
                    }
                }

                Repeater1.DataSource = listaProdotti;
                Repeater1.DataBind();

                con.Close();
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
                Label1.ForeColor = Color.Red;
            }

        }


        public class Prodotto
        {
            public int IdProdotto { get; set; }
            public string NomeProdotto { get; set; }
            public string DescrizioneProdotto { get; set; }
            public string SottotioloProdotto { get; set; }
            public decimal Prezzo { get; set; }
        }
    }
}