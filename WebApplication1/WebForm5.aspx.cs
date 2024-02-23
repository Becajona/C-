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
    public partial class WebForm5 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            BLLEntrada Objlogica = new BLLEntrada();
            string cad = "";
            GridView1.DataSource = Objlogica.MostrarEntradaTabla(ref cad);
            GridView1.DataBind();
            Label6.Text = cad;

            GridView1.AllowPaging = true;
            GridView1.PageSize = 4;
            GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int indiceRow = 0;
            int idEntrada = Convert.ToInt32(GridView1.DataKeys[GridView1.SelectedIndex].Values["IdEntrada"]);
            // Se obtiene y decodifica los valores antes de asignarlos a los TextBox
            indiceRow = GridView1.SelectedIndex;
            string valorCelda2 = HttpUtility.HtmlDecode(GridView1.Rows[indiceRow].Cells[1].Text);
            string valorCelda3 = HttpUtility.HtmlDecode(GridView1.Rows[indiceRow].Cells[2].Text);
            string valorCelda4 = HttpUtility.HtmlDecode(GridView1.Rows[indiceRow].Cells[3].Text);
            string valorCelda5 = HttpUtility.HtmlDecode(GridView1.Rows[indiceRow].Cells[4].Text);
            string valorCelda6 = HttpUtility.HtmlDecode(GridView1.Rows[indiceRow].Cells[5].Text);
            string valorCelda7 = HttpUtility.HtmlDecode(GridView1.Rows[indiceRow].Cells[6].Text);

            TextBox1.Text = valorCelda3;
            TextBox2.Text = valorCelda4;
            TextBox3.Text = valorCelda5;
            TextBox4.Text = valorCelda6;
            TextBox5.Text = valorCelda7;

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int idEntrada = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["idEntradaAuto"]);

            EntradaAuto temp = new EntradaAuto()
            {
                IdEntrada = idEntrada
            };

            string cad = "";
            BLLEntrada oblogauto = new BLLEntrada();
            oblogauto.EliminarEntradaPorId(temp, ref cad);
            Label6.Text = cad;

            GridView1.DataSource = oblogauto.MostrarEntradaTabla(ref cad);
            GridView1.DataBind();
        }
    }
}