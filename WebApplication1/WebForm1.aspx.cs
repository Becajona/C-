
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBLL;
using ClassEntidadesTaller;
using System.Drawing;


namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BLLCliente objtl = new BLLCliente();
            TextBox1.Text = objtl.ProbarConexionMysql();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Perro z= new Perro();
            z.Apodo = "Solovino";
            z.Raza = "Electrica";
            string gato = "Gato Manchas";
            TextBox2.Text= gato;

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            BLLCliente objt= new BLLCliente();
            Cliente temporal = new Cliente()
            {
                Nombre=TextBox3.Text,
                App = AppTxt.Text,
                Apm = ApmTxt.Text,
                Celular = CelularTxt.Text,
                TelOficina = TelTxt.Text,
                CorreoPer = CorreoTxt.Text,
                CorreoCorp = CorreoCorTxt.Text,
            };
            string cad = "";
            Boolean atrapa=false;
            atrapa=objt.InsertaCliente(temporal, ref cad);
            TextBox1.Text = cad;
            if(atrapa)
            {
                TextBox1.BackColor = Color.DarkBlue;
            }
            TextBox1.Text= cad;

            TextBox3.Text = "";
            AppTxt.Text = "";
            ApmTxt.Text = "";
            CelularTxt.Text = "";
            TelTxt.Text = "";
            CorreoTxt.Text = "";
            CorreoCorTxt.Text = "";

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            BLLCliente objt3 = new BLLCliente();
            List<Cliente> LaAtrapa = null;
            string cad2 = "";
            LaAtrapa = objt3.ListaClientes(ref cad2);
            //ListBox1.Items.Clear();
            TextBox1.Text = cad2;
            if(LaAtrapa != null)
            {
                foreach (Cliente g in LaAtrapa)
                {
                    ListBox1.Items.Add(g.ToString());
                }
            }
           
        }
    }
}