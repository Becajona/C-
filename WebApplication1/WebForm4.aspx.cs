using ClassBLL;
using ClassEntidadesTaller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {

            }
            else 
            {
                BLLCliente objcliente = new BLLCliente();
                List<Cliente> lista = null;
                string m = "";
                lista = objcliente.ListaClientes(ref m);
                Label1.Text = m;
                DropDownList1.Items.Clear();
                if (lista != null)
                {
                    foreach (Cliente z in lista)
                    {
                        DropDownList1.Items.Add(new ListItem(z.Nombre, z.IdCliente.ToString()));
                    }
                }

                BLLAutomovil objautomovil = new BLLAutomovil();
                List<Automovil> lista1 = null;
                lista1 = objautomovil.ListarAutomovil(ref m);
                DropDownList2.Items.Clear();
                if (lista1 != null)
                {
                    foreach (Automovil z in lista1)
                    {
                        DropDownList2.Items.Add(new ListItem(z.modelo, z.IdAuto.ToString()));
                    }
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntradaAuto temp = new EntradaAuto()
            {
                fkCliente = int.Parse(DropDownList1.Text),
                fkAuto = int.Parse(DropDownList2.Text),
                fecha = DateTime.Now,
                extra = TextBox1.Text,
                falla = TextBox2.Text
            };
            string cad = "";
            BLLEntrada oblogauto = new BLLEntrada();
            //string cad2 = "";
            oblogauto.InsertaEntrada(temp, ref cad);
            Label1.Text = cad;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = "";
        }
    }
}