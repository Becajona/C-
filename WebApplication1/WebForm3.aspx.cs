using ClassBLL;
using ClassEntidadesTaller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
            else
            {

                BLLMarca objnegMarca = new BLLMarca();
                List<Marca> lista = null;
                string m = "";
                lista = objnegMarca.ListaMarcas(ref m);
                TextBox6.Text = m;
                DropDownList1.Items.Clear();
                if (lista != null)
                {
                    foreach (Marca z in lista)
                    {
                        DropDownList1.Items.Add(new ListItem(z.marca, z.idMarc.ToString()));
                    }
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Automovil temp = new Automovil()
            {
                modelo=TextBox1.Text,
                fkmarca=int.Parse(DropDownList1.Text),
                año=int.Parse(TextBox2.Text),
                color=TextBox3.Text,
                placas=TextBox4.Text,
                estado=TextBox5.Text
            };
            string cad = "";
            BLLAutomovil oblogauto=new BLLAutomovil();
            //string cad2 = "";
            oblogauto.InsertaAutomovil(temp,ref cad);
            TextBox6.Text=cad;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox6.Text = "id asociado al text: " + DropDownList1.SelectedValue;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Automovil temp = new Automovil()
            {
                modelo = TextBox1.Text,
                fkmarca = int.Parse(DropDownList1.Text),
                año = int.Parse(TextBox2.Text),
                color = TextBox3.Text,
                placas = TextBox4.Text,
                estado = TextBox5.Text
            };
            string cad = "";
            BLLAutomovil oblogauto = new BLLAutomovil();
            //string cad2 = "";
            oblogauto.InsertaAutomovilSeguro(temp, ref cad);
            TextBox6.Text = cad;
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}
