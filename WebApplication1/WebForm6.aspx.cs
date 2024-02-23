using ClassBLL;
using ClassEntidadesTaller;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosGrid();
            }
        }

        protected void CargarDatosGrid()
        {
            BLLEntrada Objlogica = new BLLEntrada();
            string cad = "";
            GridView1.DataSource = Objlogica.MostrarEntradaTabla(ref cad);
            GridView1.DataBind();
            Label6.Text = cad;

            GridView1.AllowPaging = true;
            GridView1.PageSize = 2;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int idEntrada;

            if (GridView1.SelectedIndex != -1)
            {
                if (!int.TryParse(GridView1.SelectedRow.Cells[1].Text, out idEntrada))
                {
                    Label6.Text = "Error: No se pudo obtener el ID de la entrada seleccionada.";
                    return;
                }
            }
            else
            {
                Label6.Text = "Error: No se ha seleccionado ninguna fila en el GridView.";
                return;
            }

            int fkCliente;
            if (!int.TryParse(TextBox9.Text, out fkCliente))
            {
                Label6.Text = "Error: El valor del cliente no es válido.";
                return;
            }

            int fkAuto;
            if (!int.TryParse(TextBox10.Text, out fkAuto))
            {
                Label6.Text = "Error: El valor del auto no es válido.";
                return;
            }

            string extra = TextBox11.Text;
            string falla = TextBox12.Text;

            EntradaAuto entradaActualizada = new EntradaAuto()
            {
                IdEntrada = idEntrada,
                fkCliente = fkCliente,
                fkAuto = fkAuto,
                extra = extra,
                falla = falla
            };

            BLLEntrada bllEntrada = new BLLEntrada();
            string mensaje = "";
            bllEntrada.ActualizarEntrada(entradaActualizada, ref mensaje);

            Label6.Text = mensaje;

            CargarDatosGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceRow = GridView1.SelectedIndex;

            TextBox9.Text = HttpUtility.HtmlDecode(GridView1.Rows[indiceRow].Cells[2].Text);
            TextBox10.Text = HttpUtility.HtmlDecode(GridView1.Rows[indiceRow].Cells[3].Text);
            TextBox11.Text = HttpUtility.HtmlDecode(GridView1.Rows[indiceRow].Cells[6].Text);
            TextBox12.Text = HttpUtility.HtmlDecode(GridView1.Rows[indiceRow].Cells[5].Text);
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            CargarDatosGrid();
        }

    }
}
