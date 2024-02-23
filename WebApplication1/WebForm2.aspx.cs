using System;
using System.Collections.Generic;
//using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBLL;
namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.AllowPaging = true;

          
            GridView1.PageSize = 2;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BLLCliente Objlogica = new BLLCliente();
            //DataTable tabla = null;
            string cad = "";
            //tabla = Objlogica.MostrarClientesTabla(ref cad);
        
            GridView1.DataSource = Objlogica.MostrarClientesTabla(ref cad);
            GridView1.DataBind();
            TextBox1.Text = cad;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            BLLCliente Objlogica = new BLLCliente();
            string cad = "";
            System.Data.DataSet BDcopia;
            BDcopia = Objlogica.BdVirtual(ref cad);
            TextBox2.Text = cad;
            ListBox1.Items.Clear();
            if (BDcopia != null)
            {
                TextBox2.Text = "Total de db, "+ BDcopia.Tables.Count;
                foreach(System.Data.DataTable sa in BDcopia.Tables ){
                    ListBox1.Items.Add(sa.ToString());
                }
                Session["BDcopia"] = BDcopia;
            }


           
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        
        int contador = 0;
        protected void Button3_Click(object sender, EventArgs e)
        {
            //cast interpre
            if (Session["contador"] != null)
            {
                contador = (int)Session["contador"];
            }
            
            contador++;
            TextBox2.Text = "valor del contador, "+contador;
            Session["contador"] = contador;
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Objlogica = new BLLCliente(); 
            System.Data.DataSet dstem = null;
            if (Session["BDcopia" ]!= null)
            {
                dstem = (System.Data.DataSet)Session["BDcopia"];//indice de la tabla
                GridView2.DataSource = 
                    dstem.Tables[ListBox1.SelectedIndex];
                GridView2.DataBind();
                GridView1.DataSource =
                    dstem.Tables[ListBox1.SelectedValue]; //Nombre
                GridView1.DataBind();
            }



        }


        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            System.Data.DataSet dtt2 = null;
            if (Session["BDcopia"]!=null)
            {
                dtt2 = (System.Data.DataSet)Session["BDcopia"];
                System.Data.DataTable dttem = null;
                //dtem se encima a dt clientes
                dttem = dtt2.Tables["cliente"];
                //referencia para acceder a los data rows del datatable
                System.Data.DataRow dataRow = null;
                int g = 0;
                DropDownList1.Items.Clear();
                for (g=0; g<=dttem.Rows.Count-1; g++)
                {
                    dataRow = dttem.Rows[g];
                    DropDownList1.Items.Add("correo personal: " + dataRow[6]);
                }





            }
        }

        //obtener indice  seleccioado
        //acceder a los dtaos de las celdas espci del renglon
        //otro}
        //se muetsre en una etiqueta
        protected void Button5_Click(object sender, EventArgs e)
        {

            System.Data.DataSet ds2 = null;
            System.Data.DataTable dt4 = null;
            System.Data.DataRow drnuevo = null;
            if (Session["BDcopia"] != null)
            {
                ds2 = (System.Data.DataSet)Session["BDcopia"];

                dt4 = ds2.Tables[0];
                //como el datable cliente ya tiene la estructura de la tabla clintes que obtuvo apartir de la consulta
                //el nuevo Datarow que se quiere agregar debera de tener esa misma estructura
                //, eso se hace asi:

                drnuevo = dt4.NewRow();
                drnuevo[0] = TextBox3.Text;
                drnuevo["Nombre"] = TextBox4.Text;
                drnuevo["App"] = TextBox5.Text;
                drnuevo[3]=TextBox6.Text;   

                //agregamos al nuevo datarow que ya tiene datos, a la conexion de datarows del datatable

                dt4.Rows.Add(drnuevo);

                Session["BDcopia"] = ds2;

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
             int index = 0;
            //string Nombre = GridView1.Rows[index].Cells[2].Text;
            //string App = GridView1.Rows[index].Cells[3].Text;
            string Nombre = HttpUtility.HtmlDecode( GridView1.Rows[index].Cells[2].Text);
            string App = HttpUtility.HtmlDecode( GridView1.Rows[index].Cells[3].Text);

            Label1.Text = "Nombre:  "+ Nombre + "*******"+ "App: " + App;
            

            


        }
  
       

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }


        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
    }
}